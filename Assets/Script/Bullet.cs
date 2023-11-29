using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    public void Fire(Vector3 direction)
    {
        direction.y = 0;
        this.direction = direction;
        Destroy(this.gameObject, 10);
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = direction * speed;
    }
}
