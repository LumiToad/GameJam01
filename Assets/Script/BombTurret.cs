using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : Bullet
{
    public List<Enemy> enemies = new List<Enemy>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            enemies.Add(other.gameObject.GetComponent<Enemy>());
            return;
        }

        foreach(var enemy in enemies)
        {
            if (enemy == null) continue;

            enemy.TakeDamage(1);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            enemies.Remove(other.gameObject.GetComponent<Enemy>());
            return;
        }
    }
}
