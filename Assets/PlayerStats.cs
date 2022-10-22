using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Armor
    public static float PlayerHealth = 200;
    public static float PlayerMaxHealth = 200;
    public static float PlayerDefense = 2;

    public static float PlayerSpeed = 15;
    public static float PlayerStamina = 3;
    public static float PlayerXP = 0;
    public static float PlayerRadius = 1.2f;

    //Weapons
    public static float PlayerDamage = 20;
    public static float PlayerDamageRange = 20;
    public static float PlayerDamageCooldown = 2;
    public static float PlayerCritChance = 20;
    public static float PlayerCritDamage = 20;


    public static void RESET() {
        PlayerHealth = 100;
        PlayerMaxHealth = 100;
        PlayerDefense = 2;

        PlayerSpeed = 15;
        PlayerStamina = 3;
        PlayerXP = 0;

        PlayerDamage = 20;
        PlayerDamageRange = 20;
        PlayerDamageCooldown = 2;
        PlayerCritChance = 20;
        PlayerCritDamage = 20;
    }

}
