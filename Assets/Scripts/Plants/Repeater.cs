using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : Peashooter
{
    public override void Shoot()
    {
        base.Shoot();
        PeaBullet peaBullet2 = Instantiate(peaBulletPrefab, shootPointTransform.position + new Vector3(0.4f, 0, 0), Quaternion.identity);
        peaBullet2.SetSpeed(shootSpeed);
        peaBullet2.SetDamage(shootDamage);
    }
}
