using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        scoreText.text = "スコア: " + getScore();
    }

    public int getScore()
    {
        int score = GameObject.FindGameObjectsWithTag("Block").Length;
        if (gameManager.currentBlock != null)
            score--;
        return score;
    }
}
