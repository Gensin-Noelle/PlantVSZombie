using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jalapeno : Plant
{
    public int damage = 500;
    public float xOffset = 0;
    public float yOffset = 1;
    public JalapenoAttack jalapenoExplosionPrefab;


    public void JalapenoExplosion()
    {
        Destroy(gameObject);
        AudioManager.Instance.PlayClip(Config.jalapeno_explosion);
        Vector2 explosionPosition = new Vector2(transform.position.x + (xOffset * JalapenoCellOffset()), transform.position.y + yOffset);
        JalapenoAttack explopsion = Instantiate(jalapenoExplosionPrefab, explosionPosition, Quaternion.identity);
        explopsion.Damage = damage;
    }

    //返回火爆辣椒x轴上相对于中心方格的偏移
    public int JalapenoCellOffset()
    {
        int offset = 0; //默认为无偏移
        Dictionary<Plant, Vector2> plantSet = PlantManager.Instance.GetPlantSet();
        foreach ((Plant plant, Vector2 index) in plantSet)
        {
            if (plant != null && plant.gameObject != null && plantSet.ContainsKey(plant))
            {
                if (plant.plantType == PlantType.Jalapeno)
                {
                    offset = 4 - (int)index.y;
                }
            }
        }
        return offset;
    }
}
