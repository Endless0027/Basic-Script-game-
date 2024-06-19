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
            gameoverPanelCanvasGroup.alpha = 1f; // ����AlphaֵΪ1��������ʾ���
            gameoverPanelCanvasGroup.interactable = true; // ���ý���
        }
    }
}