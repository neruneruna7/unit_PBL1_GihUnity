using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_wall : MonoBehaviour
{
    Transform wall;
    Vector3 position;
    int mode = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        wall = this.transform;
        position = wall.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            // 90度回転
            wall.Rotate(0f, 0.5f, 0f);
            count++;
            if (count == 180)
            {
                mode = 1;
                count = 0;
            }
        }
        else if (mode == 1)
        {
            count++;
            if (count == 60)
            {
                mode = 2;
                count = 0;
            }
        }
        else if (mode == 2)
        {
            // 90度回転
            wall.Rotate(0f, -0.5f, 0f);
            count++;
            if (count == 180)
            {
                mode = 3;
                count = 0;
            }
        }
        else if (mode == 3)
        {
            count++;
            if (count == 60)
            {
                mode = 0;
                count = 0;
            }
        }
    }
}
