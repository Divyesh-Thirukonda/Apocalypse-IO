using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject spawnPointsEnemy;
    public GameObject[] listSpawnsEnemy = new GameObject[10];
    public float period = .5f;
    float nextActionTime = 0f;
    public GameObject enemy;

    void Start() {
        int i=0;
        foreach(Transform go in spawnPointsEnemy.transform) {
            listSpawnsEnemy[i] = go.gameObject;
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        int e = rnd.Next(0, 3);

        if (Time.time > nextActionTime) {
            nextActionTime = Time.time + period;
            GameObject gg = Instantiate(enemy, listSpawnsEnemy[e].transform);
            gg.transform.SetParent(null);

        }
    }
}
