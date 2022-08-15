using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockSettings tableSettings;
    public BlockSettings[] blockSettings;

    void Start()
    {
        GenerateTable();
        StartCoroutine("GenerationCoroutine");
    }

    void Update()
    {

    }

    IEnumerator GenerationCoroutine()
    {
        const int span = 2;
        while (true)
        {
            yield return new WaitForSeconds(span);
            GenerateBlock();
        }
    }

    GameObject GenerateBlock()
    {
        GameObject obj;

        int randomValue = Random.Range(0, 5);
        if (randomValue == 0)
        {
            obj = GenerateCircleBlock();
        }
        else
        {
            obj = GeneratePolygonBlock();
        }

        obj.tag = "Block";

        obj.AddComponent<Rigidbody2D>();
        obj.AddComponent<BlockManager>();

        float size = Random.Range(1.0f, 2.0f);
        obj.transform.localScale *= size;

        randomValue = Random.Range(0, blockSettings.Length);
        obj.GetComponent<Rigidbody2D>().mass = blockSettings[randomValue].mass;
        obj.GetComponent<Rigidbody2D>().sharedMaterial = blockSettings[randomValue].physicsMaterial;
        obj.GetComponent<MeshRenderer>().material = blockSettings[randomValue].material;

        return obj;
    }

    Vector2[] GeneratePolygonPoints(int numPoints)
    {
        float[] angles = new float[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            angles[i] = Random.Range(0.0f, 2 * Mathf.PI);
        }
        System.Array.Sort(angles);

        float minAngleDiff = Mathf.PI / (numPoints - 1) + 0.1f;
        for (int i = 0; i < numPoints; i++)
        {
            float angleDiff = Mathf.Abs(angles[i] - angles[(i + 1) % numPoints]);
            if (angleDiff > Mathf.PI) angleDiff = 2 * Mathf.PI - angleDiff;
            if (angleDiff < minAngleDiff) return GeneratePolygonPoints(numPoints);
        }

        Vector2[] points = new Vector2[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            points[i] = new Vector2(Mathf.Sin(angles[i]), Mathf.Cos(angles[i]));
        }
        return points;
    }

    GameObject GeneratePolygonBlock()
    {
        int numVertices = Random.Range(3, 7);
        Vector2[] points = GeneratePolygonPoints(numVertices);

        Vector3[] vertices = new Vector3[numVertices + 1];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < numVertices; i++)
        {
            vertices[i + 1] = points[i];
        }

        int[] triangles = new int[numVertices * 3];
        for (int i = 0; i < numVertices; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = 1 + i;
            triangles[i * 3 + 2] = 1 + (i + 1) % numVertices;
        }

        Vector2[] uv = new Vector2[numVertices + 1];
        uv[0] = new Vector2(0.5f, 0.5f);
        for (int i = 0; i < numVertices; i++)
        {
            uv[i + 1] = points[i] / 2 + new Vector2(0.5f, 0.5f);
        }

        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.SetUVs(0, uv);

        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(0, 10, 0);
        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<PolygonCollider2D>();
        obj.GetComponent<MeshFilter>().sharedMesh = mesh;
        obj.GetComponent<PolygonCollider2D>().points = points;

        return obj;
    }

    GameObject GenerateCircleBlock()
    {
        int numVertices = 32;
        Vector2[] points = new Vector2[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            float angle = 2 * Mathf.PI * i / numVertices;
            points[i] = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        }

        Vector3[] vertices = new Vector3[numVertices + 1];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < numVertices; i++)
        {
            vertices[i + 1] = points[i];
        }

        int[] triangles = new int[numVertices * 3];
        for (int i = 0; i < numVertices; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = 1 + i;
            triangles[i * 3 + 2] = 1 + (i + 1) % numVertices;
        }

        Vector2[] uv = new Vector2[numVertices + 1];
        uv[0] = new Vector2(0.5f, 0.5f);
        for (int i = 0; i < numVertices; i++)
        {
            uv[i + 1] = points[i] / 2 + new Vector2(0.5f, 0.5f);
        }

        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.SetUVs(0, uv);

        GameObject obj = new GameObject();
        obj.transform.position = new Vector3(0, 10, 0);
        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<PolygonCollider2D>();
        obj.GetComponent<MeshFilter>().sharedMesh = mesh;
        obj.GetComponent<PolygonCollider2D>().points = points;

        return obj;
    }

    GameObject GenerateTable()
    {
        const int halfWidth = 6;

        int numVertices = 4;
        Vector2[] points = new Vector2[numVertices];
        points[3] = new Vector2(halfWidth, 0.5f);
        points[2] = new Vector2(-halfWidth, 0.5f);
        points[1] = new Vector2(-halfWidth, -0.5f);
        points[0] = new Vector2(halfWidth, -0.5f);

        Vector3[] vertices = new Vector3[numVertices + 1];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < numVertices; i++)
        {
            vertices[i + 1] = points[i];
        }

        int[] triangles = new int[numVertices * 3];
        for (int i = 0; i < numVertices; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = 1 + i;
            triangles[i * 3 + 2] = 1 + (i + 1) % numVertices;
        }

        Vector2[] uv = new Vector2[numVertices + 1];
        uv[0] = new Vector2(0.5f, 0.5f);
        for (int i = 0; i < numVertices; i++)
        {
            uv[i + 1] = points[i] / halfWidth / 2 + new Vector2(0.5f, 0.5f);
        }

        Mesh mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        mesh.SetUVs(0, uv);

        GameObject obj = new GameObject("Table");
        obj.transform.position = new Vector3(0, 0, 0);
        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();
        obj.AddComponent<PolygonCollider2D>();
        obj.GetComponent<MeshFilter>().sharedMesh = mesh;
        obj.GetComponent<PolygonCollider2D>().points = points;

        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        obj.GetComponent<Rigidbody2D>().mass = tableSettings.mass;
        obj.GetComponent<Rigidbody2D>().sharedMaterial = tableSettings.physicsMaterial;
        obj.GetComponent<MeshRenderer>().material = tableSettings.material;

        return obj;
    }

}
