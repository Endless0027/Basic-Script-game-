using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // ScoreManager 的实例

    public Text scoreText; // 显示分数的文本组件
    private int score = 0; // 分数

    private int previousScore = 0; // 上一个关卡的分数

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
        LoadPreviousScore(); // 在开始时加载上一个关卡的分数
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
