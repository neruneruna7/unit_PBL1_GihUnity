using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_wall : MonoBehaviour
{

    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;

    int mode = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_start = myTransform.position;
        position_now = position_start;
    }

    // Update is called once per frame
    void Update()
    {
        // mode = 0 z方向に3移動
        // mode = 1 待機
        // mode = 2 z方向に-3移動
        // mode = 3 待機

        if (mode == 0)
        {
            position_now.z -= 0.05f;
            count++;
            if (position_start.z - position_now.z > 3)
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
            position_now.z += 0.05f;
            count++;
            if (position_now.z - position_start.z > 0)
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


        myTransform.position = position_now;
    }
}
