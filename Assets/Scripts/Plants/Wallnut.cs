using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallnut : Plant
{

    protected override void Start()
    {
        base.Start();
        anim.SetFloat("HealthPercent", GetHealthPercent());
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (anim != null)
        {
            anim.SetFloat("HealthPercent", GetHealthPercent());
        }
    }
}
