using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_pendulum : MonoBehaviour
{
    [SerializeField] int delay;
    [SerializeField] float x_rotate;
    [SerializeField] float y_rotate;
    [SerializeField] float z_rotate;

    bool isWaiting = true;
    int delayCount = 0;

    Transform pendulum;
    Vector3 position;
    int mode = 0;
    // int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        pendulum = this.transform;
        position = pendulum.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            delayCount++;
            if (delayCount >= delay)
            {
                isWaiting = false;
                delayCount = 0;
            }
            return;
        }

        pendulum.Rotate(x_rotate, y_rotate, z_rotate);
        // pendulum.RotateAround(origin, axis, 1f); // origin を中心に axis 周りに５度回転する
        // if (mode == 0)
        // {
        //     // 90度回転
        //     pendulum.Rotate(0f, 0f, 0.5f);
        //     count++;
        //     if (count == 180)
        //     {
        //         mode = 1;
        //         count = 0;
        //     }
        // }
        // else if (mode == 1)
        // {
        //     count++;
        //     if (count == 60)
        //     {
        //         mode = 2;
        //         count = 0;
        //     }
        // }
        // else if (mode == 2)
        // {
        //     // 90度回転
        //     pendulum.Rotate(0f, -0.5f, 0f);
        //     count++;
        //     if (count == 180)
        //     {
        //         mode = 3;
        //         count = 0;
        //     }
        // }
        // else if (mode == 3)
        // {
        //     count++;
        //     if (count == 60)
        //     {
        //         mode = 0;
        //         count = 0;
        //     }
        // }
    }
}
