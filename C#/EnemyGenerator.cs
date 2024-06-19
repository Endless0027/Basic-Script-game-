using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // ����Ԥ����
    public int numberOfEnemies = 5; // Ҫ���ɵĵ�������
    public float spawnInterval = 2f; // �������ɼ��ʱ��
    public float planeSize = 10f; // ƽ��ĳߴ�

    private void Start()
    {
        // ��ʼ��ʱ���ɵ���
        InvokeRepeating("SpawnEnemies", 0, spawnInterval);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // ���ɵ���
            Instantiate(enemyPrefab, GenerateRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // ��ƽ����������ɵ��˵�λ��
        float x = Random.Range(-planeSize / 2f, planeSize / 2f);
        float z = Random.Range(-planeSize / 2f, planeSize / 2f);

        // ����ƫ��һ���ľ��룬ȷ��������ȫλ��ƽ���Ϸ�
        Vector3 randomPosition = new Vector3(x, 0f, z) + Vector3.up * (enemyPrefab.transform.localScale.y / 2f);

        return randomPosition;
    }
}
