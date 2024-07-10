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
    [SerializeField] private TextMeshProUGUI LogText;
    [SerializeField] private int maxLogLines = 5; // 最大行数
    private List<string> logMessages = new List<string>(); // ログメッセージを保持するリスト
    public bool isPoisoned = false;
    public bool isDark = false;
    private bool f_goal; //ゴールしたかどうか

    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.value = 1f; // HPバーを満タンに

        UpdateHealthText(); // 初期HPの更新
        GameOverText.text = ""; // ゲームオーバーのテキストを空にする
        f_goal = false;
        LogText.text = ""; // ログメッセージを空にする
    }

    void Update()
    {
        ChangeState();
    }

    private void ChangeState(){
        if(isPoisoned){
            StateText.text = "Poison!";
            WriteLog("Poisoned floor!");
        }else if(isDark) {
            StateText.text = "Dark!";
            WriteLog("Darkness Area!");
        }
        else{
            StateText.text = "";
        }
    }

    public void WriteLog(string new_string)
    {
        logMessages.Add(new_string); // 新しいメッセージを追加

        // 最大行数を超えた場合、古いメッセージを削除
        if (logMessages.Count > maxLogLines)
        {
            logMessages.RemoveAt(0);
        }

        // ログメッセージをTextMeshProUGUIに表示
        LogText.text = string.Join("\n", logMessages);
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
        Dark(col);
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
    void Dark(Collision col) {
        // 衝突した物体が「ゴール」なら（※）
        if (col.gameObject.CompareTag("dark")) 
        {
            isDark = true; // 衝突フラグを上げる
            StateText.text = "Dark!!";
            LogText.text = "Dark!!"; 
        }else{
            isDark = false;
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
