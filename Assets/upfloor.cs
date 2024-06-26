using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upfloor : MonoBehaviour
{
    // Public variables to set in the Unity Editor
    public float speed = 1.0f; // Speed of upward movement
    public float distance = 5.0f; // Distance to move upward

    // Private variables to keep track of the initial position and movement
    private Vector3 initialPosition;
    private bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the floor
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position based on the initial position and distance
        Vector3 targetPosition = initialPosition + new Vector3(0, distance, 0);

        // Move the floor upwards
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the floor has reached the target position, stop moving
            if (transform.position == targetPosition)
            {
                movingUp = false;
            }
        }
    }

    // Method to set speed
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Method to set distance
    public void SetDistance(float newDistance)
    {
        distance = newDistance;
        movingUp = true; // Reset the movement when distance is changed
    }
}
