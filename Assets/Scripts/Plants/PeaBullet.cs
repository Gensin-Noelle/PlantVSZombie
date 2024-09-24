using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public GameObject peaBulletHitPrefab;
    private float speed = 3;
    private int damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
   public virtual void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Zombie"))
        {
            Destroy(gameObject);//销毁自身
            other.GetComponent<Zombie>().TakeDamage(damage);
            GameObject explosion = Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1);
        }
    }
}
