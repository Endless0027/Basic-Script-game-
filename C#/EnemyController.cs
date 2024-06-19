using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // 敌人移动速度
    private Transform player; // 玩家的Transform组件

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 假设玩家标签为"Player"
    }

    private void Update()
    {
        // 如果玩家存在
        if (player != null)
        {
            // 计算敌人朝向玩家的方向
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // 确保只在水平面上移动
            direction.Normalize();

            // 移动敌人朝向玩家的方向
            transform.position += direction * moveSpeed * Time.deltaTime;

            // 旋转敌人朝向玩家
            transform.LookAt(player);
        }
    }
}
