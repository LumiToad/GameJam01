using UnityEngine;
using UnityEngine.Playables;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyPrefab;

    private PlayableDirector playableDirector;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        SetupPlayableDirector();
    }

    public void SpawnEnemy()
    {
        var spawnedEnemy = Instantiate(EnemyPrefab);

        spawnedEnemy.transform.position = transform.position;
    }

    private void SetupPlayableDirector()
    {
        double randomTime = Random.Range(0.0f, (float)playableDirector.duration);

        playableDirector.initialTime = randomTime;
        playableDirector.Play();
    }
}
