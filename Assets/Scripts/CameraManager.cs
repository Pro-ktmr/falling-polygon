using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameManager gameManager;

    private Camera camera;
    private float size;

    void Start()
    {
        camera = GetComponent<Camera>();
        size = camera.orthographicSize;

    }

    void Update()
    {
        float blocksTop = gameManager.GetBlocksTop() + 7.0f;
        size = Mathf.Max(size, blocksTop / 2.0f);
        camera.orthographicSize = size;
        camera.transform.position = new Vector3(0, size - 3.0f, -10);
    }
}
