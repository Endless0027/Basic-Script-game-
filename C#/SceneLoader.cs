using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SampleScene; // 要跳转的场景名称

    public void LoadScene()
    {
        SceneManager.LoadScene(SampleScene);
    }
}
