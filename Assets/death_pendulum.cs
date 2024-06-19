using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_pendulum : MonoBehaviour
{
    Transform pendulum;
    // Vector3 origin = new Vector3(0f, 3f, 0f);
    // Vector3 axis = new Vector3(0f, 0f, 1f);
    Vector3 position;
    int mode = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        pendulum = this.transform;
        position = pendulum.position;
    }

    // Update is called once per frame
    void Update()
    {
        pendulum.Rotate(0f, 0f, 4f);
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
