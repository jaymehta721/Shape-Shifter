using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI startText;

    private int _currentScore;

    private void Start()
    {
        _currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startText.gameObject.SetActive(false);
        }
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        _currentScore++;
        if (_currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", _currentScore);
            bestScoreText.text = _currentScore.ToString();
        }

        SetScore();
    }

    private void SetScore()
    {
        currentScoreText.text = _currentScore.ToString();
    }
}