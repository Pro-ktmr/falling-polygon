using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject backButton;

    private BlockGenerator blockGenerator;
    private ScoreManager scoreManager;
    private TimeManager timeManager;

    private int tableHalfWidth = 6;
    private float generationSpan = 2.5f;

    public GameObject currentBlock;
    private int currentBlockX;
    private float currentBlockY = 8.0f;

    private const float playTime = 90.0f;

    public Text largeText;

    void Start()
    {
        blockGenerator = GetComponent<BlockGenerator>();
        scoreManager = GetComponent<ScoreManager>();
        timeManager = GetComponent<TimeManager>();

        GameObject table = blockGenerator.GenerateTable(tableHalfWidth);

        ShowBigCountDown();
        Invoke("GameBegin", 3.0f);
    }

    void ShowBigCountDown()
    {
        if (largeText.text == "")
            largeText.text = "3";
        else if (largeText.text == "3")
            largeText.text = "2";
        else if (largeText.text == "2")
            largeText.text = "1";
        else if (largeText.text == "1")
            largeText.text = "";

        if (largeText.text != "")
            Invoke("ShowBigCountDown", 1.0f);
    }

    void GameBegin()
    {
        timeManager.time = playTime;
        timeManager.doesDecrease = true;
        GenerateNewBlock();
    }

    public void GameEnd()
    {
        CancelInvoke("GenerateNewBlock");
        if (currentBlock != null)
        {
            Destroy(currentBlock);
        }
        currentBlock = null;

        largeText.text = "おしまい！";

        Invoke("FreezeField", 3.0f);
    }

    void FreezeField()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }


        int score = scoreManager.getScore();
        largeText.text = "スコア: " + score;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            largeText.text += "\n★ハイスコア";
        }

        backButton.SetActive(true);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void GenerateNewBlock()
    {
        currentBlock = blockGenerator.GenerateBlock();
        currentBlockX = 0;
        currentBlockY = GetBlocksTop() + 5.0f;
        currentBlock.transform.position = new Vector3(currentBlockX, currentBlockY, 0);
    }

    public float GetBlocksTop()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        float blocksTop = 3.0f;
        foreach (GameObject block in blocks)
        {
            blocksTop = Mathf.Max(blocksTop, block.transform.position.y);
        }
        return blocksTop;
    }

    public void DropCurrentBlock()
    {
        if (currentBlock != null)
        {
            currentBlock.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            currentBlock.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -0.1f));

            currentBlock = null;

            Invoke("GenerateNewBlock", generationSpan);
        }
    }

    public void MoveCurrentBlockLeft()
    {
        if (currentBlock != null)
        {
            currentBlockX = System.Math.Max(currentBlockX - 1, -tableHalfWidth);
            currentBlock.transform.position = new Vector3(currentBlockX, currentBlockY, 0);
        }
    }

    public void MoveCurrentBlockRight()
    {
        if (currentBlock != null)
        {
            currentBlockX = System.Math.Min(currentBlockX + 1, tableHalfWidth);
            currentBlock.transform.position = new Vector3(currentBlockX, currentBlockY, 0);
        }
    }

}
