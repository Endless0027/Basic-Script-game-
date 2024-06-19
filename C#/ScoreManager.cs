using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // ScoreManager ��ʵ��

    public Text scoreText; // ��ʾ�������ı����
    private int score = 0; // ����

    private int previousScore = 0; // ��һ���ؿ��ķ���

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPreviousScore(); // �ڿ�ʼʱ������һ���ؿ��ķ���
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetPreviousScore()
    {
        return previousScore;
    }

    public void SavePreviousScore()
    {
        previousScore = score;
    }

    private void LoadPreviousScore()
    {
        if (PlayerPrefs.HasKey("PreviousScore"))
        {
            previousScore = PlayerPrefs.GetInt("PreviousScore");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
