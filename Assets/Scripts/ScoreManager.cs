using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    void Update()
    {
        int length = GameObject.FindGameObjectsWithTag("Block").Length;
        scoreText.text = "Score: " + length;
    }
}
