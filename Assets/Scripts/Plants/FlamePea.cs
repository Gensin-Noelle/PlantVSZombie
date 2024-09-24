using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePea : Peashooter
{
    public GameObject FireEffectPrefab;
    public float offsetX;
    public float offsetY;
    private SpriteRenderer flamePeaRenderer;

    protected override void Start()
    {
        base.Start();
        flamePeaRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Shoot()
    {
        flamePeaRenderer.color = Color.red;
        AudioManager.Instance.PlayClip(Config.flame);

        Vector2 index = GetPlantIndex(this);
        int generateNum = CalcGenerateNum(index);
        for (int i = 1; i <= generateNum; i++)
        {
            GameObject fireEffect = Instantiate(FireEffectPrefab, transform.position + new Vector3(i * offsetX, offsetY, 0), Quaternion.identity);
            fireEffect.GetComponent<FireEffect>().SetDamage(shootDamage);
        }

        float delay = shootDuration * 0.2f;
        Invoke(nameof(TransitionToNormal), delay);
    }

    /**
    计算需要生成的火焰特效数量
    */
    private int CalcGenerateNum(Vector2 plantPosition)
    {
        int shootRange = 8 - (int)plantPosition.y;
        return shootRange;
    }

    private void TransitionToNormal()
    {
        flamePeaRenderer.color = Color.white;
    }
}
