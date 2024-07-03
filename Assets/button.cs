using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject wallToMove; // 動かしたい壁のGameObject
    public Vector3 openPosition; // 開く位置
    public float moveSpeed = 5.0f; // 移動速度

    private bool isOpening = false; // 開いているかどうかのフラグ
    private Vector3 closedPosition; // 閉じている位置

    void Start()
    {
        // 初期位置を設定
        closedPosition = wallToMove.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
        }
    }

    void Update()
    {
        if (isOpening)
        {
            // 壁を開く処理
            float step = moveSpeed * Time.deltaTime;
            wallToMove.transform.position = Vector3.MoveTowards(wallToMove.transform.position, openPosition, step);

            // 開き終わったらフラグをリセット
            if (wallToMove.transform.position == openPosition)
            {
                isOpening = false;
            }
        }
    }
}
