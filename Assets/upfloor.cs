using System.Collections;
using UnityEngine;

public class upfloor : MonoBehaviour
{
    public float speed = 1.0f; // 移動速度
    public float distance = 5.0f; // 上昇距離
    public float waitTimeBeforeUp = 2.0f; // 上昇前の待機時間
    public float waitTimeAtTop = 2.0f; // 上昇後の待機時間

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    // 初期化処理
    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(0, distance, 0);
        StartCoroutine(StartMovement());
    }

    IEnumerator StartMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimeBeforeUp); // 上昇前の待機

            // 上昇
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTimeAtTop); // 頂上での待機

            // 下降
            while (transform.position != initialPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }

    // 速度を設定するメソッド
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // 距離を設定するメソッド
    public void SetDistance(float newDistance)
    {
        distance = newDistance;
        targetPosition = initialPosition + new Vector3(0, distance, 0); // 目標位置を更新
    }

    // 上昇前の待機時間を設定するメソッド
    public void SetWaitTimeBeforeUp(float newWaitTimeBeforeUp)
    {
        waitTimeBeforeUp = newWaitTimeBeforeUp;
    }

    // 上昇後の待機時間を設定するメソッド
    public void SetWaitTimeAtTop(float newWaitTimeAtTop)
    {
        waitTimeAtTop = newWaitTimeAtTop;
    }
}
