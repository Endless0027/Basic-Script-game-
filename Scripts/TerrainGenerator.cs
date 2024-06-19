using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject terrainPrefab;
    private GameObject currentTerrain;
    private Vector3 spawnPosition;
    public AudioSource clickSound;

    void Start()
    {
        SpawnTerrain();
    }

    void Update()
    {
        // ������λ�ã������µĵ��ο�
        if (transform.position.z > currentTerrain.transform.position.z - 20) // ����ҽӽ���ǰ���ο��ĩ��ʱ�����µĵ��ο�
        {
            SpawnTerrain();
            clickSound.Play();
        }
    }

    void SpawnTerrain()
    {
        if (currentTerrain == null)
        {
            currentTerrain = Instantiate(terrainPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            spawnPosition = currentTerrain.transform.Find("EndPosition").position;
            float offset = currentTerrain.transform.Find("EndPosition").position.x - currentTerrain.transform.Find("StartPosition").position.x;
            spawnPosition += new Vector3(offset, 0, 0);
            currentTerrain = Instantiate(terrainPrefab, spawnPosition, Quaternion.identity);
        }

        // ������ҵ���Ծ����������ο�����ɷ���һ��
        Vector3 jumpDirection = currentTerrain.transform.Find("JumpDirection").position - transform.position;
        transform.forward = new Vector3(jumpDirection.x, 0, jumpDirection.z).normalized;
    }
}
