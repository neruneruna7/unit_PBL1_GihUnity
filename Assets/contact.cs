using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class contact : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ContactText;
    private int CountactCount;

    // Start is called before the first frame update
    void Start()
    {
        CountactCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
    if (other.transform.parent != null && other.transform.parent.gameObject.name == "wall")
    {
        CountactCount++;
        if (ContactText != null)
        {
            ContactText.text = string.Format("Hit wall {0}", CountactCount);
        }
        else
        {
            Debug.LogError("ContactText is not assigned in the inspector.");
        }
    }
    }

}
