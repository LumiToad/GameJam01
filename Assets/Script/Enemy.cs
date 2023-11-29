using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;

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
}
