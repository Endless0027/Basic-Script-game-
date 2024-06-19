using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int scoreValue = 10; // 击败此敌人的得分值
    public ScoreManager scoreManager; // 引用 ScoreManager 组件

    // 当敌人被击败时调用
    public void Die()
    {
        // 增加玩家得分
        scoreManager.IncreaseScore(scoreValue);
        // 其他处理，比如播放死亡动画等
        Debug.Log("Enemy died"); // 添加调试日志
        scoreManager.IncreaseScore(scoreValue);
    }
}
