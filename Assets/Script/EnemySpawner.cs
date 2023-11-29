using UnityEngine;
using UnityEngine.Playables;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    [SerializeField]
    private float startCooldown = 3.0f;

    private float cooldown;

    private float time;

    private void Awake()
    {
        RandomizeTimer();
        cooldown = startCooldown;
    }

    private void Update()
    {
        time += Time.deltaTime;

        cooldown = startCooldown - (Ressources.Difficulty * 0.1f);

        if (time >= cooldown)
        {
            time = 0;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        var spawnedEnemy = Instantiate(EnemyPrefab);

        spawnedEnemy.transform.position = transform.position;
    }

    private void RandomizeTimer()
    {
        float randomTime = Random.Range(0.0f, cooldown);

        time = randomTime;
    }
}
