using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI GameOverText;
    public float maxHealth = 100f;
    public float currentHealth; // publicに変更

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText(); // 初期HPの更新
        GameOverText.text = ""; // ゲームオーバーのテキストを空にする
    }

    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthText(); // HPの更新

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        SelectStatus(col);
    }

    public void SelectStatus(Collision col)
    {
        if (col.gameObject.CompareTag("HPup"))
        {
            currentHealth += 10f;
            UpdateHealthText(); // HPの表示を更新
        }
    }

    private void Die()
    {
        // プレイヤーの死亡処理
        Debug.Log("Player has died.");
        HealthText.text = ""; // HPの表示を空にする
        GameOverText.text = "Game Over"; // ゲームオーバーのメッセージを表示
    }

    private void UpdateHealthText()
    {
        HealthText.text = "HP: " + currentHealth.ToString("F0"); // 小数点以下なしで表示
    }
}
