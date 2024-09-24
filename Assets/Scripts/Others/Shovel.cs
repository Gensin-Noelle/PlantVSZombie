using UnityEngine;

public class Shovel : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        if (!TryGetComponent<BoxCollider2D>(out boxCollider2D))
        {
            boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        }
        boxCollider2D.isTrigger = true;
    }

    void Update()
    {
        FollowCursor();
        if (Input.GetMouseButtonDown(0))
        {
            TryRemovePlant();
        }
    }

    private void FollowCursor()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseWorldPosition;
    }

    private void TryRemovePlant()
    {
        // 检查铲子位置是否有植物对象
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider2D.size, 0);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Plants"))
            {
                RemovePlant(collider.gameObject);
                break;
            }
        }
    }

    private void RemovePlant(GameObject plant)
    {
        Destroy(plant);
        PlantManager.Instance.RemovePlant(plant.GetComponent<Plant>());
        AudioManager.Instance.PlayClip(Config.palnt);
        //Cell.Instance.SetCurrentPlantToNull();
    }
}
