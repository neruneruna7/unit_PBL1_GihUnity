using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Jump : MonoBehaviour
{
private bool isJumping;
Rigidbody rb ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        if(isJumping == false){
        rb.velocity = new Vector3(0,10,0);
       
        }
        isJumping = true;
        }
 
 
    }
 
    void OnCollisionEnter(Collision col){
    if(col.gameObject.tag == "ground"){
    isJumping = false;
    }
    }
}
