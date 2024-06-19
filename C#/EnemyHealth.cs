using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int scoreValue = 10; // ���ܴ˵��˵ĵ÷�ֵ
    public ScoreManager scoreManager; // ���� ScoreManager ���

    // �����˱�����ʱ����
    public void Die()
    {
        // ������ҵ÷�
        scoreManager.IncreaseScore(scoreValue);
        // �����������粥������������
        Debug.Log("Enemy died"); // ��ӵ�����־
        scoreManager.IncreaseScore(scoreValue);
    }
}
