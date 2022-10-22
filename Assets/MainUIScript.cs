using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Threading;

public class MainUIScript : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider enemyHealthSlider;
    public Slider xpLeveler;
    public int xpLevel = 1;
    public TMPro.TextMeshProUGUI xpLevelText;
    public int amtToLevelXp;

    PlayerCombat PlayerCombat;

    GameObject Player;

    public GameObject panel;
    public TMPro.TextMeshProUGUI coinText;
    public GameObject dummy;

    public TMPro.TextMeshProUGUI timerText;

    public int rpgLevel = 0; //use in RPG script to change splash radius and damage (0 means locked)
    public GameObject rpgReference;

    public int ffLevel = 0;
    public GameObject ffReference;

    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerCombat = Player.GetComponent<PlayerCombat>();
        InvokeRepeating("eeee", .1f, 5f);
    }

    public GameObject PanelLevel;
    public GameObject refButton0;
    public GameObject refButton1;
    public GameObject refButton2;
    System.Random prnd = new System.Random();
    public float iTimer = 0;

    public TMPro.TextMeshProUGUI progressXPText;

    void eeee() {
        if(refButton0.activeInHierarchy == false) {
            refButton0.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
        }
        if(refButton1.activeInHierarchy == false) {
            refButton1.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
        }
        if(refButton2.activeInHierarchy == false) {
            refButton2.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
        }
    }
    void Update()
    {
        if(rpgLevel > 0) {
            rpgReference.SetActive(true);
        }
        if(ffLevel > 0) {
            ffReference.SetActive(true);
        }

        /*
        foreach(Transform sloti in panel.transform) {
            System.Random rnd = new System.Random();
            int e = rnd.Next(0, 3); // 0, 1, 2

            // Items Dict with itemLevel, image... {rpgLevel, rpgImg}

            Transform tmpi = sloti.transform.GetChild(0);
            // tmpi.GetComponent<Image>().SourceImage = items[img];
            
            // on button click, increase items[level] by 1
        }
        */

        xpLevelText.text = xpLevel.ToString();
        if(xpLevel <= 3) {amtToLevelXp = 10;} else if(xpLevel>=4 && xpLevel<15) {amtToLevelXp = xpLevel*2;} else if(xpLevel>=10) {amtToLevelXp = (int)Mathf.Pow(xpLevel, 2)/5;}
        progressXPText.text = "Progress: " + xpLeveler.value.ToString() + " / " + xpLeveler.maxValue.ToString();

        xpLeveler.value = PlayerStats.PlayerXP;
        xpLeveler.maxValue = amtToLevelXp;


        /*
        if(refButton0.activeInHierarchy == false) {iTimer = iTimer + 1 * Time.deltaTime;}

        if(iTimer >= 2f && refButton0.activeInHierarchy == false) {
            refButton0.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
            refButton1.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
            refButton2.GetComponent<SlotChoose>().Shuffle(); // prnd.Next(0, 3); // 0, 1, 2
        }
        */

        if(PlayerStats.PlayerXP>=amtToLevelXp) {
            PlayerStats.PlayerXP = 0;
            xpLevel++;
            PanelLevel.SetActive(true);
            xpLeveler.maxValue = amtToLevelXp;
        }
        healthSlider.value = PlayerStats.PlayerHealth;
        healthSlider.maxValue = PlayerStats.PlayerMaxHealth;

        if(PlayerStats.PlayerHealth <= 0) {
            foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy")) {
                Destroy(fooObj);
            }
            PlayerArmor.playerArmor = PlayerArmor.Armors.none;
            PlayerStats.RESET();
            SceneManager.LoadScene(0);
        }
        timerText.text = ((int)Time.timeSinceLevelLoad/60).ToString() + ":" + ((int)Time.timeSinceLevelLoad%60).ToString();
        healthSlider.value = PlayerStats.PlayerHealth;
        // Debug.Log("Value is: " + healthSlider.value.ToString() + " and " + PlayerStats.PlayerHealth.ToString());
        healthSlider.maxValue = PlayerStats.PlayerMaxHealth;

        // staminaSlider.value = PlayerStats.PlayerStamina;
        // staminaSlider.maxValue = 3;

        // For every item slot in the panel, the text of the slot is set to the name of the game object, which is 0,1,2,3,4.
        // So If the number's inventoryItems[item] is empty, set the text to nothing. Else, set it to the name of the inventoryItems[item]'s name
        /*
        foreach(Transform slot in panel.transform) {
            Transform tmp = slot.transform.GetChild(0);
            int ooo = Int32.Parse(tmp.gameObject.name);
            if(PlayerCombat.inventoryItems[ooo] == null) {
                tmp.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = " ";
            } else {
                tmp.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerCombat.inventoryItems[ooo].name;
            }
        }

        foreach(Transform sloti in panel1.transform) {
            Transform tmpi = sloti.transform.GetChild(0);
            int oooi = Int32.Parse(tmpi.gameObject.name);
            
            if(PlayerCombat.MatsItems[oooi] == null) {
                tmpi.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = " ";
            } else {
                tmpi.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerCombat.MatsItems[oooi].name;
            }
        }
        */
        // coinText.text = PlayerCombat.coins.ToString();
        /*
        RaycastHit ihit;
        if (Physics.Raycast(Player.GetComponent<AdvancedMovement>().cam.transform.position, Player.GetComponent<AdvancedMovement>().cam.transform.forward, out ihit, 10)){
            if (ihit.collider.tag == "Shootable") {
                enemyHealthSlider.value = ihit.collider.gameObject.GetComponent<EnemyCombat>().enemyHealth;
                enemyHealthSlider.maxValue = ihit.collider.gameObject.GetComponent<EnemyCombat>().enemyMaxHealth;
                Slider oo = Instantiate(enemyHealthSlider);
                oo.gameObject.transform.parent = dummy.transform;
                Destroy(oo.gameObject, 1f);
            }
        }
        */
    }


    public static bool paused = false;

    public void PauseGame() {
        paused = true;
    }

    public void ResumeGame() {
        paused = false;
    }

}
