using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ZombieState
{
    Move,
    Eating,
    Died
}
public class Zombie : MonoBehaviour
{
    ZombieState zombieState = ZombieState.Move;
    public float moveSpeed = 2;
    public int damage = 5;
    public float damageDuration = 2;
    public int maxHealth = 100;
    private int currentHealth;
    private float damageTimer = 0;
    private Rigidbody2D rd;
    private Animator anim;
    private Plant currentEatPlant;
    private bool isFrozen = false;
    private Coroutine freezeCoroutine;
    private float deathDelay = 1.07f;
    private float originalMoveSpeed; // 用于存储原始速度
    private readonly Color freezeColor = new Color32(0x00, 0x60, 0xFF, 0xFF); // RGB(0, 96, 255)

    //private bool haveHead = true;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        originalMoveSpeed = moveSpeed; // 保存原始速度
    }

    // Update is called once per frame
    void Update()
    {
        switch (zombieState)
        {
            case ZombieState.Move:
                MoveUpdate();
                break;
            case ZombieState.Eating:
                EatingUpdate();
                break;
            case ZombieState.Died:
                break;
        }
    }

    void MoveUpdate()
    {
        if (isFrozen)
        {
            return; // If frozen, do not move
        }
        rd.MovePosition(rd.position + moveSpeed * Time.deltaTime * Vector2.left);

    }

    void EatingUpdate()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer > damageDuration && currentEatPlant != null)
        {
            AudioManager.Instance.PlayClip(Config.eat);
            currentEatPlant.TakeDamage(damage);
            damageTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Plants"))
        {
            anim.SetBool("isEating", true);
            TransitionToEating();
            currentEatPlant = other.GetComponent<Plant>();
        }
        else if (other.CompareTag("House"))
        {
            //结束游戏
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plants"))
        {
            anim.SetBool("isEating", false);
            zombieState = ZombieState.Move;
            currentEatPlant = null;
        }
    }

    private void TransitionToEating()
    {
        zombieState = ZombieState.Eating;
        damageTimer = 0; //转换为吃状态重置计时器
    }

    public virtual void TakeDamage(int damage, string attackType = "Normal")
    {
        //if (currentHealth <= 0) return; //避免反复去世
        currentHealth -= damage;
        float healthPercent = (float)currentHealth / maxHealth;
        //Debug.Log("父类，僵尸血量百分比:" + healthPercent.ToString());
        anim.SetBool("Boom", false);
        if (currentHealth <= 0)
        {
            anim.SetBool(attackType == "Boom" ? "Boom" : "null", true);
            Died(deathDelay);
            currentHealth = -1;
        }
        anim.SetFloat("HealthPercent", healthPercent);
    }

    private void Died(float time = 0)
    {
        zombieState = ZombieState.Died;
        ZombieManager.Instance.RemoveZombie(this); //将僵尸从僵尸列表移除
        Destroy(gameObject, time);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int health)
    {
        currentHealth = health;
    }

    public void Freeze()
    {
        if (isFrozen)
        {
            return; // 如果正在冻结中，直接返回，避免开启新的冻结协程
        }
        if (freezeCoroutine != null)
        {
            StopCoroutine(freezeCoroutine);
            moveSpeed = originalMoveSpeed; // 恢复原始速度
            GetComponent<SpriteRenderer>().color = Color.white; // 恢复为白色
        }
        freezeCoroutine = StartCoroutine(FreezeCoroutine());
    }

    private IEnumerator FreezeCoroutine()
    {
        isFrozen = true;
        GetComponent<SpriteRenderer>().color = freezeColor;
        yield return new WaitForSeconds(1.0f); // Slow down period
        moveSpeed /= 2;
        yield return new WaitForSeconds(2.0f); // Freeze period
        moveSpeed = originalMoveSpeed; // 恢复原始速度
        GetComponent<SpriteRenderer>().color = Color.white;
        isFrozen = false;
    }

}
