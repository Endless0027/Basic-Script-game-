using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // �����ƶ��ٶ�
    private Transform player; // ��ҵ�Transform���

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������ұ�ǩΪ"Player"
    }

    private void Update()
    {
        // �����Ҵ���
        if (player != null)
        {
            // ������˳�����ҵķ���
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // ȷ��ֻ��ˮƽ�����ƶ�
            direction.Normalize();

            // �ƶ����˳�����ҵķ���
            transform.position += direction * moveSpeed * Time.deltaTime;

            // ��ת���˳������
            transform.LookAt(player);
        }
    }
}
