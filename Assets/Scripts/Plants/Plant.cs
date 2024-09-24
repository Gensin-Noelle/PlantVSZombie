using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantState = PlantState.Disable;
    public PlantType plantType = PlantType.SunFlower;
    public Animator anim;
    public int maxHealth = 100;
    private int currentHealth;
    private float healthPercent = 1;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        TransitionToDisable();
    }

    private void Update()
    {
        switch (plantState)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
        }
    }

    private void DisableUpdate()
    {

    }

    protected virtual void EnableUpdate()
    {

    }

    private void TransitionToDisable()
    {
        plantState = PlantState.Disable;
        GetComponent<Animator>().enabled = false; //让植物处于不动的状态
        GetComponent<BoxCollider2D>().enabled = false; //禁用碰撞器
    }

    public void TransitionToEnable()
    {
        plantState = PlantState.Enable;
        GetComponent<Animator>().enabled = true; //让植物处于动画的状态
        GetComponent<BoxCollider2D>().enabled = true; //当植物被种植才启用碰撞器
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthPercent = (float)currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            Died();
        }
    }

    private void Died()
    {
        Destroy(gameObject);
        PlantManager.Instance.RemovePlant(this);
    }

    public float GetHealthPercent()
    {
        return healthPercent;
    }
}
