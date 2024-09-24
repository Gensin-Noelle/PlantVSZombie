using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnCleaner : MonoBehaviour
{
    private float speed = 3;
    private bool isMove = false;
    private bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
        if (!isPlay) //确保只播放一次
        {
            AudioManager.Instance.PlayClip(Config.small_cart);
            isPlay = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().SetCurrentHealth(0);
            other.GetComponent<Zombie>().TakeDamage(0); //用于更新血量
            Destroy(gameObject, 10);
            isMove = true;
        }
    }
}
