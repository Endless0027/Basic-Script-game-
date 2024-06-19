using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public AudioClip deathSound; // ������Ч
    private AudioSource audioSource; // ��ƵԴ
    public ScoreManager scoreManager; // ���� ScoreManager �ű�
    public int scoreValue = 10; // ���ٵ���ʱ�ĵ÷�ֵ

    private void Start()
    {
        audioSource = GetComponent < AudioSource>(); // ��ȡ��ƵԴ���
    }

    // ����ײ����ʱ����
    private void OnTriggerEnter(Collider other)
    {
        // ������������ӵ�
        if (other.CompareTag("Bullet"))
        {
            // �����ӵ�
            Destroy(other.gameObject);

            // ���ٵ��˶���
            DestroyEnemy();
        }
    }

    // ���ٵ��˵ķ���
    void DestroyEnemy()
    {
        // ������ǰ�ٴμ����Ϸ�����Ƿ��ѱ�����
        if (gameObject != null)
        {
            // ����������Ч
            if (deathSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            // ���ӷ���
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(scoreValue);
            }

            // ���ٵ��˶���
            Destroy(gameObject);
        }
    }
}
