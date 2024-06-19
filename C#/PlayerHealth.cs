using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // 玩家的最大生命值
    private int currentHealth; // 玩家当前的生命值

    public HealthBar healthBar; // 血条脚本的引用

    private void Start()
    {
        currentHealth = maxHealth; // 初始化玩家的生命值
        healthBar.SetMaxHealth(maxHealth); // 设置血条的最大值
        UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--; // 玩家生命值减少
            Debug.Log("Player health: " + currentHealth);

            if (currentHealth <= 0)
            {
                GameOver(); // 游戏结束
            }

            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealth(currentHealth); // 更新血条的显示
    }

    private void GameOver()
    {
        // 在这里添加切换至游戏结束场景的代码
        SceneManager.LoadScene("Level1");
    }
}
