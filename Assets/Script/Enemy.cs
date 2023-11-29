using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int maxHP = 5;

    public int hp;

    [SerializeField]
    private int damage = 1;

    private NavMeshAgent agent;
    private PlayableDirector playableDirector;
    private DamageNumbers damageNumbers;
    private HPBar hpBar;

    public Coin coin;

    public GameObject deathVfxPrefab;

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
        hpBar = GetComponentInChildren<HPBar>();
        hp = maxHP;
        hpBar.SetHealthBar(maxHP, hp);
    }

    public void TakeDamage(int damage)
    {
        if ( damageNumbers != null)
        {
            damageNumbers.PrintDamageNumber(damage ,Color.white);
        }

        hp -= damage;

        if (hp <= 0)
        {
            var coins = Instantiate(coin);
            coins.transform.position = transform.position;
            Ressources.enemyKills += 1;
            EnemyDeath();
        }

        Debug.Log($"Enemy Damaged: {damage}, current HP: {hp}");
        hpBar.SetHealthBar(maxHP, hp);

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
        var deathVfx = Instantiate(deathVfxPrefab);
        deathVfx.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void WalkTowardsTarget()
    {
        agent.SetDestination(Base.Instance.transform.position);
    }

    public void AttackTarget()
    {
        Base.Instance.TakeDamage(damage);
        EnemyDeath();
    }

}
