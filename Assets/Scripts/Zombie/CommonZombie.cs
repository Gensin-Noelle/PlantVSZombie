using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonZombie : Zombie
{
    public GameObject zombieHeadPrefab;
    private bool haveHead = true;

    public override void TakeDamage(int damage, string attackType = "Normal")
    {
        base.TakeDamage(damage, attackType);
        float healthPercent = (float)GetCurrentHealth() / maxHealth;
        //Debug.Log("子类，僵尸血量百分比:" + healthPercent.ToString());
        //实例化僵尸头
        if (healthPercent < 0.4f && haveHead && attackType.Equals("Normal"))
        {
            GameObject zombieHead = Instantiate(zombieHeadPrefab, transform.position, Quaternion.identity);
            Destroy(zombieHead, 1);
            haveHead = false;
        }
    }
}
