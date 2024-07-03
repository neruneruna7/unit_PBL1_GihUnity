using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private Slider HealthBar;

    [SerializeField] private TextMeshProUGUI StateText;

    [SerializeField] private TextMeshProUGUI GameOverText;
    public float maxHealth = 100f;
    private float currentHealth;
    public bool isPoisoned = false;

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.value = 1f; // HPバーを満タンに

        UpdateHealthText(); // 初期HPの更新
        GameOverText.text = ""; // ゲームオーバーのテキストを空にする
    }

    void Update()
    {
        ChangeState();
    }

    private void ChangeState(){
        if(isPoisoned){
            StateText.text = "Poison!";
        }else{
            StateText.text = "";
        }
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
        HealthBar.value = (float)currentHealth / (float)maxHealth; ;
    }
}
