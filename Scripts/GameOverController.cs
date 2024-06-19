using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public CanvasGroup gameoverPanelCanvasGroup;

    private bool gameIsOver = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane") && !gameIsOver)
        {
            gameIsOver = true;
            gameoverPanelCanvasGroup.alpha = 1f; // 设置Alpha值为1，立即显示面板
            gameoverPanelCanvasGroup.interactable = true; // 启用交互
        }
    }
}