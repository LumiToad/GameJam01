using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}
