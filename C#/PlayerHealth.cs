using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // ��ҵ��������ֵ
    private int currentHealth; // ��ҵ�ǰ������ֵ

    public HealthBar healthBar; // Ѫ���ű�������

    private void Start()
    {
        currentHealth = maxHealth; // ��ʼ����ҵ�����ֵ
        healthBar.SetMaxHealth(maxHealth); // ����Ѫ�������ֵ
        UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--; // �������ֵ����
            Debug.Log("Player health: " + currentHealth);

            if (currentHealth <= 0)
            {
                GameOver(); // ��Ϸ����
            }

            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.SetHealth(currentHealth); // ����Ѫ������ʾ
    }

    private void GameOver()
    {
        // ����������л�����Ϸ���������Ĵ���
        SceneManager.LoadScene("Level1");
    }
}
