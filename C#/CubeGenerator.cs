using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // ����Ԥ����
    public int numberOfCubes = 5; // Ҫ���ɵķ�������
    public float spawnInterval = 2f; // �������ɼ��ʱ��
    public float destructionDelay = 4f; // ���������ӳ�ʱ��
    public float planeSize = 10f; // ƽ��ĳߴ�

    private void Start()
    {
        // ��ʼ��ʱ���ɷ���
        InvokeRepeating("SpawnCubes", 0, spawnInterval);
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            // ���ɷ���
            GameObject cube = Instantiate(cubePrefab, GenerateRandomPosition(), Quaternion.identity);
            // ��ָ���ӳٺ��������ɵķ���
            Destroy(cube, destructionDelay);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // ��ƽ����������ɷ����λ��
        float x = Random.Range(-planeSize / 2f, planeSize / 2f);
        float z = Random.Range(-planeSize / 2f, planeSize / 2f);

        // ����ƫ��һ���ľ�d��ȷ��������ȫλ��ƽ���Ϸ�
        Vector3 randomPosition = new Vector3(x, 0f, z) + Vector3.up * (cubePrefab.transform.localScale.y / 2f);

        return randomPosition;
    }
}
