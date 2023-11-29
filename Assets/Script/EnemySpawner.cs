using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    public void SpawnEnemy()
    {
        var spawnedEnemy = Instantiate(EnemyPrefab);

        spawnedEnemy.transform.position = transform.position;
    }
}
