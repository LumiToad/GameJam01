using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;

    [SerializeField]
    private int damage = 1;

    private NavMeshAgent agent;
    private PlayableDirector playableDirector;

    private Base playerBase;

    public bool isBaseInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Base>() != null)
        {
            isBaseInRange = true;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            EnemyDeath();
        }

    }

    public void AITick()
    {
        if (isBaseInRange)
        {
            AttackTarget();
            return;
        }

        WalkTowardsTarget();
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }

    public void WalkTowardsTarget()
    {
        agent.SetDestination(playerBase.transform.position);
    }

    public void AttackTarget()
    {
        playerBase.TakeDamage(damage);
    }

}
