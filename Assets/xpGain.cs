using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpGain : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Mathf.Sqrt(Mathf.Pow(GameObject.Find("Player").transform.position.x - transform.position.x, 2)+Mathf.Pow(GameObject.Find("Player").transform.position.z - transform.position.z, 2)) < PlayerStats.PlayerRadius) {
            PlayerStats.PlayerXP += 1;
            Destroy(gameObject);
        }
    }
}
