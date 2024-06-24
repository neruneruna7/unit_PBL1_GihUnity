using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_floor : MonoBehaviour
{

    [SerializeField] GameObject src;
    [SerializeField] GameObject dst;

    Transform myTransform;
    Vector3 position_now;

    int mode = 0;
    int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position_now = src.transform.position;
        // コンソールにsrcとdstの位置を表示
        Debug.Log("src: " + src.transform.position);
        Debug.Log("dst: " + dst.transform.position);        
    }

    // Update is called once per frame
    void Update()
    {
        // mode = 0 srcからdstへ移動
        // mode = 1 待機
        // mode = 2 dstからsrcへ移動
        // mode = 3 待機
        // 2つのオブジェクトの間を行ったり来たりする
        // 2つのオブジェクトの位置から移動方向を決定
        Debug.Log("now: " + position_now);


        switch (mode)
        {
            case 0: // z方向に移動
                position_now = Vector3.MoveTowards(position_now, dst.transform.position, 0.05f);
                if (Vector3.Distance(position_now, dst.transform.position) < 0.01f)
                {
                    mode = 1;
                    count = 0;
                }
                break;
            case 1: // 待機
                count++;
                if (count == 60) // 1秒後
                {
                    mode = 2;
                    count = 0;
                }
                break;
            case 2: // z方向に逆に移動
                position_now = Vector3.MoveTowards(position_now, src.transform.position, 0.05f);
                if (Vector3.Distance(position_now, src.transform.position) < 0.01f)
                {
                    mode = 3;
                    count = 0;
                }
                break;
            case 3: // 待機
                count++;
                if (count == 60) // 1秒後
                {
                    mode = 0;
                    count = 0;
                }
                break;
        }

        myTransform.position = position_now; // 実際に位置を更新
    }

    // 上に乗ったプレイヤーが移動床とともに移動するように
    // オブジェクトの親子関係を変更
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 触れたobjの親を移動床にする
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 触れたobjの親をなくす
            other.transform.SetParent(null);
        }
    }
}
