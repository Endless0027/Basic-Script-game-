using UnityEngine;
using UnityEngine.UI;

public class SavedScoreDisplay : MonoBehaviour
{
    public Text savedScoreText;

    void Start()
    {
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            int savedScore = PlayerPrefs.GetInt("SavedScore");
            savedScoreText.text = "Score:" + savedScore.ToString();
        }
        else
        {
            savedScoreText.text = "No saved score found";
        }
    }
}
