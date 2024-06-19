using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // 方块预制体
    public int numberOfCubes = 5; // 要生成的方块数量
    public float spawnInterval = 2f; // 方块生成间隔时间
    public float destructionDelay = 4f; // 方块销毁延迟时间
    public float planeSize = 10f; // 平面的尺寸

    private void Start()
    {
        // 开始定时生成方块
        InvokeRepeating("SpawnCubes", 0, spawnInterval);
    }

    private void SpawnCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            // 生成方块
            GameObject cube = Instantiate(cubePrefab, GenerateRandomPosition(), Quaternion.identity);
            // 在指定延迟后销毁生成的方块
            Destroy(cube, destructionDelay);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // 在平面上随机生成方块的位置
        float x = Random.Range(-planeSize / 2f, planeSize / 2f);
        float z = Random.Range(-planeSize / 2f, planeSize / 2f);

        // 向上偏移一定的距禿，确保方块完全位于平面上方
        Vector3 randomPosition = new Vector3(x, 0f, z) + Vector3.up * (cubePrefab.transform.localScale.y / 2f);

        return randomPosition;
    }
}
