using UnityEngine;

public class PuzzlePeaBullet : PeaBullet
{
    private Vector3 targetPosition;
    private readonly float targetUpdateInterval = 0.1f; // 更新目标位置的时间间隔
    private float targetUpdateTime;

    void Start()
    {
        targetUpdateTime = Time.time;
        UpdateTargetPosition(); // 初始化目标位置
        Destroy(gameObject, 180); // 60秒后销毁子弹对象
    }

    public override void Update()
    {
        if (Time.time >= targetUpdateTime)
        {
            UpdateTargetPosition(); // 定期更新目标位置
            targetUpdateTime = Time.time + targetUpdateInterval;
        }

        // 计算子弹朝向目标位置的方向
        Vector3 direction = (targetPosition - transform.position).normalized;
        // 子弹朝目标位置移动
        transform.Translate(GetSpeed() * Time.deltaTime * direction, Space.World);
    }

    private void UpdateTargetPosition()
    {
        // 获取鼠标位置并转换为世界坐标
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 确保z轴为0，因为我们在2D游戏中

        // 在鼠标附近生成随机位置
        float randomRange = 3.0f; // 调整范围可以控制子弹分布的区域大小
        targetPosition = mousePosition + (Vector3)(Random.insideUnitCircle * randomRange);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            // Destroy(this.gameObject); // 碰到僵尸时销毁自身
            if (other.TryGetComponent<Zombie>(out var zombie))
            {
                zombie.TakeDamage(GetDamage()); // 对僵尸造成伤害
            }
            // GameObject explosion = Instantiate(peaBulletHitPrefab, transform.position, Quaternion.identity); // 在子弹位置生成爆炸效果
            // Destroy(explosion, 1); // 1秒后销毁爆炸效果对象
        }
    }
}
