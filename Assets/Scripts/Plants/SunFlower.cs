using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
{
    public GameObject sunPrefab;
    public float produceDuration = 2f;
    private float produceTimer = 0;

    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 2;


    //生产阳光由动画帧事件控制
    public void ProduceSun()
    {
        GameObject sun = Instantiate(sunPrefab, transform.position, Quaternion.identity);
        //实现阳光在植物两边随机掉落
        float distance = Random.Range(jumpMinDistance, jumpMaxDistance);
        distance = Random.Range(0, 2) < 1 ? -distance : distance;
        //    Vector2 targetPosition = transform.position;
        //    targetPosition.x += distance;
        Vector3 targetPosition = transform.position + new Vector3(distance, 0, 0);

        sun.GetComponent<Sun>().MoveParabolic(transform.position, targetPosition, 5f, 45f); ;
    }

    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        if (produceTimer > produceDuration)
        {
            anim.SetTrigger("isGlowing");
            produceTimer = 0;
        }
    }
}
