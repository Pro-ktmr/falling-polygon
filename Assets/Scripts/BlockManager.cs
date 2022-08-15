using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }
    }
}
