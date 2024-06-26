using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private bool isJumping;
    private Rigidbody rb;

    // 移動速度と回転速度の調整
    float moveSpeed = 2f;  // 移動速度
    float rotationSpeed = 10f; // 回転速度を増加
    float jumpForce = 5f;  // ジャンプの強さ
    float vision = 0f;

    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        
        // ジャンプ状態の初期化
        isJumping = false;
        
        // ゲームのフレームレートを 60 FPS に設定
        Application.targetFrameRate = 60;

        
    }

    void Update()
    {
        // WASD キーによる移動制御
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        


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
        

        
        // 視点の回転 (マウスの横移動で)
        vision = Input.GetAxis("Mouse X") * rotationSpeed ;
        transform.Rotate(0f, vision, 0f);
        

        // 移動方向の計算
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        
        //移動処理
        Vector3 velocity = moveDirection * moveSpeed * Time.deltaTime;
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
    }
}
