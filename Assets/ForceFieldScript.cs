using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour
{
    public float FF_radius = 3f;
    public float FF_damage = 4f;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel >= 5) {
            GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel = 5;
        }
        FF_radius = GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel*3;
        FF_damage = GameObject.Find("GAME").GetComponent<MainUIScript>().ffLevel*30;
        gameObject.transform.localScale = new Vector3(FF_radius, .1f, FF_radius);
        foreach(GameObject target in GameObject.FindGameObjectsWithTag("Enemy")) {
            if(Mathf.Sqrt(Mathf.Pow(transform.position.x - target.gameObject.transform.position.x, 2)+Mathf.Pow(transform.position.z - target.gameObject.transform.position.z, 2)) < FF_radius) {
                target.GetComponent<EnemyCombat>().TakeDamage(FF_damage * Time.deltaTime);
            }
        }
    }

    
}
