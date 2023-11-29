using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : MonoBehaviour
{
    public DamageZone Explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.ToString() == "Default")
        {
            Destroy(this.gameObject);
            var boom = Instantiate(Explosion);
            boom.transform.position = transform.position;
        }
    }
}
