using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float gameTime = 60f; // 游戏时间（秒）
    public Text timerText; // 显示计时器的文本组件
    public Text scoreText; // 显示分数结果的文本组件
    public GameObject gameOverPanel;

    private bool gameEnded = false; // 游戏是否已结束
    private float currentTime; // 当前剩余时间

    private void Start()
    {
        currentTime = gameTime; // 初始化当前剩余时间
        UpdateTimerText();
        StartCoroutine(GameTimer());
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
    }

    private void ShowScoreResult()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
        scoreText.gameObject.SetActive(true);
        SaveScore(); // 保存分数
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", ScoreManager.Instance.GetScore());
        PlayerPrefs.Save();
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void EndGame()
    {
        gameEnded = true;
        ShowScoreResult();
        ShowGameOverPanel(); // 显示游戏结束的弹出窗口
        LoadNextLevel(); // 直接切换至下一关场景
    }

    private void LoadNextLevel()
    {
        // 在这里添加切换至下一关场景的代码
        // 例如，假设下一关场景名称为 "Level2"
        SceneManager.LoadScene("Level1");
    }

    private System.Collections.IEnumerator GameTimer()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimerText();
        }

        if (!gameEnded)
        {
            EndGame();
        }
    }
}
