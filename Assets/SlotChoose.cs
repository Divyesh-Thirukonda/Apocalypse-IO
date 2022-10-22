using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SlotChoose : MonoBehaviour
{
    public Sprite rpgSpr;
    public Sprite ffSpr;
    public string[] items = {"rpg", "ff"};
    public Dictionary<string, Sprite> openWith;
    public int e = 0;
    System.Random rnd = new System.Random();
    public TextMeshProUGUI textTitle;

    public void Shuffle() {
        e = rnd.Next(0, 2); // 0, 1
        openWith = new Dictionary<string, Sprite>(){{"rpg", rpgSpr}, {"ff", ffSpr}};
        items[0] = "rpg";
        items[1] = "ff";

        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = openWith[items[e]];
        
        textTitle.text = "";

        switch (items[e].ToString())
        {
          case "rpg":
            textTitle.text = "rpg";
            for (int i = 0; i < GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel; i++) 
            {
              textTitle.text = textTitle.text + "X";
            }
            if(textTitle.text.Length <8) {
                while(textTitle.text.Length <8) {
                    textTitle.text = textTitle.text + "O";
                }
            }
            break;
          case "ff":
            textTitle.text = "ff";
            for (int i = 0; i < GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel; i++) 
            {
              textTitle.text = textTitle.text + "X";
            }
            if(textTitle.text.Length <7) {
                while(textTitle.text.Length <7) {
                    textTitle.text = textTitle.text + "O";
                }
            }
            break;
        }
    }

    public void Selection(int count) {
        string testee;
        var reversed = openWith.ToDictionary(x => x.Value, x => x.Key);
        switch (gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite.name)
        {
          case "RPG":
            GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel++;
            Debug.Log(reversed[gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite]);
            break;
          case "FF":
            GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel++;
            Debug.Log(reversed[gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite]);
            break;
        }
    }
}
