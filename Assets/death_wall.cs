using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_wall : MonoBehaviour
{

    [SerializeField] GameObject activate_field;
    Transform myTransform;
    Vector3 position_start;
    Vector3 position_now;

    int mode = 0;
    bool is_active = false;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_start = myTransform.position;
        position_now = position_start;
        activate_field.GetComponent<in_player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activate_field.GetComponent<in_player>().is_player_in)
        {
            is_active = true;
        }

        if (is_active)
        {
            position_now.x += 1f;

            myTransform.position = position_now;
        }
    }
}
