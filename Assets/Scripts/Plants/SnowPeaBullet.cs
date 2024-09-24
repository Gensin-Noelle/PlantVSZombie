using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPeaBullet : PeaBullet
{
    public float offsetX;
    public float offsetY;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(gameObject);//销毁自身
            other.GetComponent<Zombie>().TakeDamage(GetDamage());
            other.GetComponent<Zombie>().Freeze();
            GameObject explosion = Instantiate(peaBulletHitPrefab, transform.position + new Vector3(offsetX, offsetY, 0), Quaternion.identity);
            Destroy(explosion, 1);
        }
    }
}
