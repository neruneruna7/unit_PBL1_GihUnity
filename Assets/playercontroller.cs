using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI GameOverText;
    public float maxHealth = 100f;
    public float currentHealth; // publicに変更
    [SerializeField] private Slider HealthBar;

    [SerializeField] private TextMeshProUGUI StateText;

    public bool isPoisoned = false;
    private bool f_goal; //ゴールしたかどうか

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.value = 1f; // HPバーを満タンに

        UpdateHealthText(); // 初期HPの更新
        GameOverText.text = ""; // ゲームオーバーのテキストを空にする
        f_goal = false;
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

    void OnCollisionEnter(Collision col)
    {
        SelectStatus(col);
        Goal(col);
    }

    public void SelectStatus(Collision col)
    {
        if (col.gameObject.CompareTag("HPup"))
        {
            currentHealth += 10f;
            UpdateHealthText(); // HPの表示を更新
        }
    }

    void Goal(Collision col) {
        // 衝突した物体が「ゴール」なら（※）
        if (col.gameObject.CompareTag("Goal")) 
        {
            f_goal = true; // 衝突フラグを上げる
            GameOverText.text = "Goal!!"; // ゴールメッセージを表示
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
