using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float gravity = 9.8f; // 重力加速度
    public int point = 50;
    public float disappearTime = 3;
    private bool isRecycle = false;

    // 让阳光按抛物线运动到目标位置
    public void MoveParabolic(Vector3 startPosition, Vector3 targetPosition, float initialVelocity, float angle)
    {
        StartCoroutine(ParabolicCoroutine(startPosition, targetPosition, initialVelocity, angle));
    }

    private IEnumerator ParabolicCoroutine(Vector3 startPosition, Vector3 targetPosition, float initialVelocity, float angle)
    {
        float time = 0f;

        while (time <= 0.8f)
        {
            time += Time.deltaTime;

            // 计算当前位置
            float currentX = Mathf.Lerp(startPosition.x, targetPosition.x, time);
            float currentY = startPosition.y + (initialVelocity * time * Mathf.Sin(angle * Mathf.Deg2Rad) - 0.5f * gravity * time * time);
            float currentZ = -1; //将Z轴设为-1，优先检测

            // 更新位置
            transform.position = new Vector3(currentX, currentY, currentZ);

            yield return null;
        }
        // 当阳光到达目标位置时销毁
        //Destroy(gameObject, disappearTime);
        //当阳光到达目标位置一定时间就自动回收
        Invoke(nameof(OnMouseDown), disappearTime);

    }

    public void OnMouseDown()
    {
        if (!isRecycle) // 确保阳光只被回收一次
        {
            StartCoroutine(MoveToTarget(SunManager.Instance.GetSunPointTextPosition()));
        }
    }

    public IEnumerator DelayedOnMouseDown()
    {
        yield return new WaitForSeconds(disappearTime); // 延迟
        OnMouseDown();
    }

    public IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        Vector3 startPosition = transform.position;

        float totalTime = 1.0f; // 总时间
        float currentTime = 0f;

        // 移动到目标位置
        while (currentTime < totalTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / totalTime; // 当前时间的百分比
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        //到达位置后增加阳光点数并销毁物体
        SunManager.Instance.AddSun(point);
        Destroy(gameObject);

        isRecycle = true;
    }

}
