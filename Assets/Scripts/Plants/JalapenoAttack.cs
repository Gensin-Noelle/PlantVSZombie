using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalapenoAttack : MonoBehaviour
{
    private int damage = 1000;
    public int Damage { get { return damage; } set { damage = value; } }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().TakeDamage(damage, "Boom");
        }
    }


}
