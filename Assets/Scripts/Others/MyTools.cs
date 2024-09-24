using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTools : MonoBehaviour
{
    public static IEnumerator MoveToTarget(GameObject gameObject, Vector3 targetPosition, Action callback = null)
    {
        Vector3 startPosition = gameObject.transform.position;

        float totalTime = 1.0f; // 总时间
        float currentTime = 0f;

        // 移动到目标位置
        while (currentTime < totalTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / totalTime; // 当前时间的百分比
            gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // 移动完成后调用回调函数（如果有）
        callback?.Invoke();
    }
}
