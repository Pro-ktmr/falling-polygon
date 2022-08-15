using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "ハイスコア: " + highScore;
    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("FallingScene");
    }
}
