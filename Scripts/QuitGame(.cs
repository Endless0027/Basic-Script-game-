using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public AudioSource clickSound; // 声明一个AudioSource来播放点击音效

    public GameManager gameManager; // 引用GameManager脚本

    void Start()
    {
        // 获取GameManager脚本的引用
        gameManager = FindObjectOfType<GameManager>();
    }

    public void QuitGame()
    {
        if (clickSound != null)
        {
            clickSound.Play(); // 如果音效存在，则播放音效
        }

        // 保存最高分
        if (gameManager != null)
        {
            gameManager.ResetHighScore(); // 重置最高分并保存
        }

        Application.Quit(); // 退出游戏
    }
}
