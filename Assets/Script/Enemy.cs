using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;

    private NavMeshAgent agent;
    private Base playerBase;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            EnemyDeath();
        }

    }

    public void EnemyDeath()
    {

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkTowardsTarget()
    {
        agent.SetDestination(playerBase.transform.position);
    }


}
