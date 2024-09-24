using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketheadZombie : Zombie
{
    public override void TakeDamage(int damage, string attackType = "Normal")
    {
        base.TakeDamage(damage, attackType);
        if(attackType.Equals("Normal"))
        {
            AudioManager.Instance.PlayClip(Config.shieldhit, 0.5f); //播放铁桶僵尸被攻击音效
        }
    }
}
