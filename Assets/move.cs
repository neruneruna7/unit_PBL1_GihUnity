using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{
    private bool isJumping;
    private Rigidbody rb;

    // 移動速度と回転速度の調整
    float moveSpeed;  // 移動速度
    float rotationSpeed; // 回転速度を増加
    float jumpForce;  // ジャンプの強さ
    float vision = 0f; // 視点
    int confusion; // 状態

    public TextMeshProUGUI SpeedText; // 移動速度表示用のUI
    public TextMeshProUGUI JumpText; // ジャンプ力表示用のUI

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        // ジャンプ状態の初期化
        isJumping = false;

        // ゲームのフレームレートを 60 FPS に設定
        Application.targetFrameRate = 60;

        // ステータス初期値設定
        moveSpeed = 2f;
        rotationSpeed = 2f;
        jumpForce = 2f;
        confusion = 0;

        // 初期値を表示
        UpdateSpeedText();
        UpdateJumpText();
    }

    void Update()
    {
        // WASDキーによる移動制御
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (confusion == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveVertical += 1f; // 前進
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveVertical -= 1f; // 後退
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal += 1f; // 右移動
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal -= 1f; // 左移動
            }
        }


        
        
        if (confusion == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                moveVertical += 1f; // 前進
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveVertical -= 1f; // 後退
            }
            if (Input.GetKey(KeyCode.W))
            {
                moveHorizontal += 1f; // 右移動
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveHorizontal -= 1f; // 左移動
            }
        } 

        
        // 視点の回転 (マウスの横移動で)
        vision = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(0f, vision, 0f);

        // 移動方向の計算
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        
        //移動処理
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);

        // スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // 地面に接触したときにジャンプ状態をリセット
        if (col.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
        // ステータス選択時の操作
        SelectStatus(col);
        // 混乱時の操作
        StateConfusion(col);
    }

    void SelectStatus(Collision col)
    {
        if (col.gameObject.CompareTag("speedup"))
        {
            moveSpeed += 1f;
            UpdateSpeedText(); // 移動速度の表示を更新
        }

        if (col.gameObject.CompareTag("jumpup"))
        {
            jumpForce += 1f;
            UpdateJumpText(); // ジャンプ力の表示を更新
        }


    }

    void StateConfusion(Collision col)
    {
        if (col.gameObject.CompareTag("confusion"))
        {
            confusion = 1;
        }
        if (col.gameObject.CompareTag("nomal"))
        {
            confusion = 0;
        }
    }

    void UpdateSpeedText()
    {
        SpeedText.text = moveSpeed.ToString("F1");
    }

    void UpdateJumpText()
    {
        JumpText.text = jumpForce.ToString("F1");
    }
}
