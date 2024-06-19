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
        // 检测玩家位置，生成新的地形块
        if (transform.position.z > currentTerrain.transform.position.z - 20) // 当玩家接近当前地形块的末端时生成新的地形块
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

        // 调整玩家的跳跃方向以与地形块的生成方向一致
        Vector3 jumpDirection = currentTerrain.transform.Find("JumpDirection").position - transform.position;
        transform.forward = new Vector3(jumpDirection.x, 0, jumpDirection.z).normalized;
    }
}
