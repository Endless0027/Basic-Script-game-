using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人预制体
    public int numberOfEnemies = 5; // 要生成的敌人数量
    public float spawnInterval = 2f; // 敌人生成间隔时间
    public float planeSize = 10f; // 平面的尺寸

    private void Start()
    {
        // 开始定时生成敌人
        InvokeRepeating("SpawnEnemies", 0, spawnInterval);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // 生成敌人
            Instantiate(enemyPrefab, GenerateRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        // 在平面上随机生成敌人的位置
        float x = Random.Range(-planeSize / 2f, planeSize / 2f);
        float z = Random.Range(-planeSize / 2f, planeSize / 2f);

        // 向上偏移一定的距离，确保敌人完全位于平面上方
        Vector3 randomPosition = new Vector3(x, 0f, z) + Vector3.up * (enemyPrefab.transform.localScale.y / 2f);

        return randomPosition;
    }
}
