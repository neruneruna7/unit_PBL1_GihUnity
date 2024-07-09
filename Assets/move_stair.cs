using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_stair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
