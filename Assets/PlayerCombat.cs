using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{

    void Update()
    {
        PlayerStats.PlayerHealth += 2*Time.deltaTime;

        System.Random rnd = new System.Random();
        PlayerStats.PlayerCritDamage = rnd.Next(5, 20);
        PlayerStats.PlayerCritChance = rnd.Next(0, 5);

        if(PlayerStats.PlayerHealth >= PlayerStats.PlayerMaxHealth) {
            PlayerStats.PlayerHealth = PlayerStats.PlayerMaxHealth;
        }
        if(PlayerStats.PlayerStamina >= 3) {
            PlayerStats.PlayerStamina = 3;
        }

        if(PlayerStats.PlayerCritChance == 1) {
            PlayerStats.PlayerDamage += (PlayerStats.PlayerCritDamage+ (PlayerStats.PlayerCritDamage*(PlayerStats.PlayerCritDamage/100)));
        }

    }

    void OnCollisionEnter(Collision col) {
        if(col.collider.gameObject.tag == "Enemy") {
            PlayerStats.PlayerHealth -= col.gameObject.GetComponent<EnemyCombat>().enemyDamage;
        }
    }
}
