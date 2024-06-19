using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float gameTime = 60f; // ��Ϸʱ�䣨�룩
    public Text timerText; // ��ʾ��ʱ�����ı����
    public Text scoreText; // ��ʾ����������ı����
    public GameObject gameOverPanel;

    private bool gameEnded = false; // ��Ϸ�Ƿ��ѽ���
    private float currentTime; // ��ǰʣ��ʱ��

    private void Start()
    {
        currentTime = gameTime; // ��ʼ����ǰʣ��ʱ��
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
        SaveScore(); // �������
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
        ShowGameOverPanel(); // ��ʾ��Ϸ�����ĵ�������
        LoadNextLevel(); // ֱ���л�����һ�س���
    }

    private void LoadNextLevel()
    {
        // ����������л�����һ�س����Ĵ���
        // ���磬������һ�س�������Ϊ "Level2"
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
