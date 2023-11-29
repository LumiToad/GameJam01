using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    public Transform bulletSpawnPoint;
    public Bullet projectile;
    private Tower tower;

    public Tower normalTower;
    public Tower bombTower;

    public Image normalTowerHighlight;
    public Image bombTowerHighlight;

    public LayerMask mask;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        tower = normalTower;
    }

    private void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            var position = hit.point;
            position.y = transform.position.y;
            transform.LookAt(hit.point);
        }

        Move();
        Attack();
        SpawnTurret();
        SelectTurret();
    }

    private void Move()
    {
        var direction = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            direction.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;
        }

        rb.velocity = (direction * speed);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(projectile);
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.Fire(transform.forward);
        }
    }

    void SpawnTurret()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask))
            {
                var turret = Instantiate(tower);
                var position = hit.point;
                position.y = transform.position.y;
                turret.transform.position = position;
            }
        }
    }

    void SelectTurret()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            normalTowerHighlight.gameObject.SetActive(false);
            bombTowerHighlight.gameObject.SetActive(false);

            tower = normalTower;
            normalTowerHighlight.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            normalTowerHighlight.gameObject.SetActive(false);
            bombTowerHighlight.gameObject.SetActive(false);

            tower = bombTower;
            bombTowerHighlight.gameObject.SetActive(true);
        }
    }
}
