using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
