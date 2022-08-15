using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BlockGenerator blockGenerator;
    private int tableHalfWidth = 6;
    private float generationSpan = 2.5f;

    private GameObject currentBlock;
    private int currentBlockX;
    private float currentBlockY = 8.0f;

    void Start()
    {
        blockGenerator = this.GetComponent<BlockGenerator>();
        GameObject table = blockGenerator.GenerateTable(tableHalfWidth);
        Invoke("GenerateNewBlock", 1.0f);
    }

    void Update()
    {

    }

    void GenerateNewBlock()
    {
        currentBlock = blockGenerator.GenerateBlock();
        currentBlockX = 0;
        currentBlock.transform.position = new Vector3(currentBlockX, currentBlockY, 0);
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
