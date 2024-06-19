using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public AudioSource clickSound; // ����һ��AudioSource�����ŵ����Ч

    public GameManager gameManager; // ����GameManager�ű�

    void Start()
    {
        // ��ȡGameManager�ű�������
        gameManager = FindObjectOfType<GameManager>();
    }

    public void QuitGame()
    {
        if (clickSound != null)
        {
            clickSound.Play(); // �����Ч���ڣ��򲥷���Ч
        }

        // ������߷�
        if (gameManager != null)
        {
            gameManager.ResetHighScore(); // ������߷ֲ�����
        }

        Application.Quit(); // �˳���Ϸ
    }
}
