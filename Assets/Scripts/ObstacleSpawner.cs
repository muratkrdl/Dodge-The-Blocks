using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Transform blockSpawnPoint1;
    [SerializeField] Transform blockSpawnPoint2;
    [SerializeField] Transform blockSpawnPoint3;
    [SerializeField] Transform blockSpawnPoint4;
    [SerializeField] Transform blockSpawnPoint5;

    [SerializeField] GameObject blockPrefab;

    [SerializeField] float blockSpawnTime = 2f;

    List<Transform> blockSpawnPoints = new List<Transform>();
    List<GameObject> blocks = new List<GameObject>();

    int randomIndex;

    void Start()
    {
        blockSpawnPoints.Add(blockSpawnPoint1);
        blockSpawnPoints.Add(blockSpawnPoint2);
        blockSpawnPoints.Add(blockSpawnPoint3);
        blockSpawnPoints.Add(blockSpawnPoint4);
        blockSpawnPoints.Add(blockSpawnPoint5);
        StartCoroutine(SpawnBlocks());
    }

    IEnumerator SpawnBlocks()
    {
        while(true)
        {
            yield return new WaitForSeconds(blockSpawnTime);

            for (int i = 0; i < 5; i++)
            {
                GameObject block = Instantiate(blockPrefab);
                block.transform.position = blockSpawnPoints[i].position;
                blocks.Add(block);
            }

            randomIndex = Random.Range(0,5);
            Destroy(blocks[randomIndex].gameObject);

            blocks.Clear();
        }
    }

}
