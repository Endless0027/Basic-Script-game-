using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public AudioClip deathSound; // 死亡音效
    private AudioSource audioSource; // 音频源
    public ScoreManager scoreManager; // 引用 ScoreManager 脚本
    public int scoreValue = 10; // 销毁敌人时的得分值

    private void Start()
    {
        audioSource = GetComponent < AudioSource>(); // 获取音频源组件
    }

    // 当碰撞发生时调用
    private void OnTriggerEnter(Collider other)
    {
        // 如果碰到的是子弹
        if (other.CompareTag("Bullet"))
        {
            // 销毁子弹
            Destroy(other.gameObject);

            // 销毁敌人对象
            DestroyEnemy();
        }
    }

    // 销毁敌人的方法
    void DestroyEnemy()
    {
        // 在销毁前再次检查游戏对象是否已被销毁
        if (gameObject != null)
        {
            // 播放死亡音效
            if (deathSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            // 增加分数
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(scoreValue);
            }

            // 销毁敌人对象
            Destroy(gameObject);
        }
    }
}
