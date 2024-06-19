using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class time : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI GoalMessage;
    private float elapsedTime;

    private int f_Goal;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        f_Goal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (f_Goal == 0)
        {
            elapsedTime += Time.deltaTime;
        }
        TextTime.text = string.Format("Time {0:f2} sec", elapsedTime);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "ゴール")
        {
            f_Goal = 1;
            GoalMessage.text = "Goal!!";
        }
    }
}
