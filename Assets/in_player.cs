using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class in_player : MonoBehaviour
{
    public bool is_player_in = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            is_player_in = true;
        }
    }
}
