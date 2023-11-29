using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRange : MonoBehaviour
{
    public Player player;
    public Tower turret;

    public float bonusSpeed = 0.1f;

    public ParticleSystem levelUpVFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            player = other.GetComponent<Player>();
        }
    }

    private void Update()
    {
        if(player != null && Input.GetKeyDown(KeyCode.E) && Ressources.value >= 10)
        {
            Ressources.value -= 10;
            Debug.LogWarning("Turret got Upgraded");
            turret.fireCooldown_ = Mathf.Clamp(turret.fireCooldown_ - bonusSpeed, 0.1f, 10000);
            levelUpVFX.gameObject.SetActive(true);
            levelUpVFX.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            player = null;
        }
    }
}
