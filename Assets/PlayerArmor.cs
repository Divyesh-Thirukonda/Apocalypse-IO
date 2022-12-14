using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmor : MonoBehaviour
{
    public enum Armors {
        none, woodenArmor, stoneArmor, metalArmor
    }

    public static Armors playerArmor = Armors.none;

    // Update is called once per frame
    void Update()
    {
        if (playerArmor == Armors.none) {
            PlayerStats.PlayerMaxHealth = 100;
            PlayerStats.PlayerDefense = 2;
        }
        if (playerArmor == Armors.woodenArmor) {
            PlayerStats.PlayerMaxHealth = 130;
            PlayerStats.PlayerDefense = 10;
        }
        if (playerArmor == Armors.stoneArmor) {
            PlayerStats.PlayerMaxHealth = 180;
            PlayerStats.PlayerDefense = 15;
        }
        if (playerArmor == Armors.metalArmor) {
            PlayerStats.PlayerMaxHealth = 250;
            PlayerStats.PlayerDefense = 30;
        }
    }

    public void woodenArmor() {
        playerArmor = Armors.woodenArmor;
    }
}
