using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text Score;
    public Text BestScore;
    public Text GameOver;

    private int m_Score = 0;
    private int m_BestScore = 0;

    void Start()
    {
        GameOver.enabled = false;
        m_Score = 0;
        // m_BestScore = PlayerPrefs.GetInt("Max", 0); // 加载最高分，默认为0
        //Debug.Log(ScoreBillbord.maxScore);
        //BestScore.text = ScoreBillbord.maxScore .ToString();
        RefreshScore();
    }

    public void  RefreshScore()
    {
        string str = string.Format("Score: {0}", m_Score);
        Score.text = str;
        str = string.Format("Max: {0}", ScoreBillbord .maxScore);
        BestScore.text = str;
    }

    public void AddScore(int sc = 1)
    {
        m_Score += sc;
        if (m_Score > m_BestScore)
        {
            m_BestScore = m_Score;
            ScoreBillbord.maxScore = m_BestScore;
            PlayerPrefs.SetInt("Max", m_BestScore); // 保存最高分
        }
        RefreshScore();
    }

    public void ShowGameOver()
    {
        GameOver.enabled = true;
        string str = string.Format("Game Over\nYour Score: {0}\nBest Score: {1}", m_Score, m_BestScore);
        GameOver.text = str;
    }
}
