using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    public float poisonDamage = 10f; // 毒のダメージ量（毎秒）

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playercontroller player = other.GetComponent<playercontroller>();
            if (player != null)
            {
                player.TakeDamage(poisonDamage * Time.deltaTime); // 毎秒ダメージを与える
            }
        }
    }
}
