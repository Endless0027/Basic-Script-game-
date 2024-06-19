using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // 敌人预制体
    public int poolSize = 10; // 对象池大小
    public float activationInterval = 1.0f; // 激活间隔时间

    private List<GameObject> pooledEnemies = new List<GameObject>();

    private void Start()
    {
        // 初始化对象池
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = InstantiateEnemy();
            enemy.SetActive(false); // 初始时设置为未激活状态
            pooledEnemies.Add(enemy);
        }

        // 启动定时激活敌人的协程
        StartCoroutine(ActivateEnemiesRoutine());
    }

    private GameObject InstantiateEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        EnemyController enemyController = newEnemy.GetComponent<EnemyController>();
      
        return newEnemy;
    }

    private IEnumerator ActivateEnemiesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(activationInterval);

            // 激活对象池中的一个未激活的敌人
            GameObject enemy = GetPooledEnemy();
            if (enemy != null)
            {
                enemy.SetActive(true);
                // 在这里可以设置敌人的位置等属性
            }
        }
    }

    public GameObject GetPooledEnemy()
    {
        // 从对象池中获取未激活的敌人
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeSelf)
            {
                return pooledEnemies[i];
            }
        }

        // 如果对象池中没有未激活的敌人，则根据需要动态扩展对象池
        GameObject newEnemy = InstantiateEnemy();
        pooledEnemies.Add(newEnemy);
        return newEnemy;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false); // 将敌人设置为未激活状态
    }
}
