using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpgScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 0.1f, 3f);
    }

    public GameObject rpgPrefab;

    void Attack() {
        GameObject bullet = Instantiate(rpgPrefab, transform);
        bullet.gameObject.transform.parent = null;
    }
}
