using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SampleScene; // Ҫ��ת�ĳ�������

    public void LoadScene()
    {
        SceneManager.LoadScene(SampleScene);
    }
}
