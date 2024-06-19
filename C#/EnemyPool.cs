using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab; // ����Ԥ����
    public int poolSize = 10; // ����ش�С
    public float activationInterval = 1.0f; // ������ʱ��

    private List<GameObject> pooledEnemies = new List<GameObject>();

    private void Start()
    {
        // ��ʼ�������
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = InstantiateEnemy();
            enemy.SetActive(false); // ��ʼʱ����Ϊδ����״̬
            pooledEnemies.Add(enemy);
        }

        // ������ʱ������˵�Э��
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

            // ���������е�һ��δ����ĵ���
            GameObject enemy = GetPooledEnemy();
            if (enemy != null)
            {
                enemy.SetActive(true);
                // ������������õ��˵�λ�õ�����
            }
        }
    }

    public GameObject GetPooledEnemy()
    {
        // �Ӷ�����л�ȡδ����ĵ���
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].activeSelf)
            {
                return pooledEnemies[i];
            }
        }

        // ����������û��δ����ĵ��ˣ��������Ҫ��̬��չ�����
        GameObject newEnemy = InstantiateEnemy();
        pooledEnemies.Add(newEnemy);
        return newEnemy;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false); // ����������Ϊδ����״̬
    }
}
