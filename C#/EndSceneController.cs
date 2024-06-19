using UnityEngine;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int previousScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Previous Score: " + previousScore.ToString();
    }
}
