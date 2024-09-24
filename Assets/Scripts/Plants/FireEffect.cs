using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    private int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().TakeDamage(damage, "Boom");
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
