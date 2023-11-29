using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int hp = 5;

    [SerializeField]
    private int damage = 1;

    private NavMeshAgent agent;
    private PlayableDirector playableDirector;
    private DamageNumbers damageNumbers;

    [HideInInspector]
    public bool isBaseInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.GetComponent<Base>() != null)
        {
            isBaseInRange = true;
        }
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playableDirector = GetComponent<PlayableDirector>();
        damageNumbers = GetComponentInChildren<DamageNumbers>();
    }

    public void TakeDamage(int damage)
    {
        if ( damageNumbers != null)
        {
            damageNumbers.PrintDamageNumber(damage ,Color.red);
        }

        hp -= damage;

        if (hp <= 0)
        {
            EnemyDeath();
        }

        Debug.Log($"Enemy Damaged: {damage}, current HP: {hp}");

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
        agent.SetDestination(Base.Instance.transform.position);
    }

    public void AttackTarget()
    {
        Base.Instance.TakeDamage(damage);
        Destroy(gameObject);
    }

}
