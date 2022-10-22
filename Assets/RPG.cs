using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : MonoBehaviour
{
    public GameObject enemyToFireAt;
    Rigidbody rb;
    float xDiff;
    float zDiff;

    float lengthA;
    float lengthB;
    float lengthC;
    float theta;

    void Start() {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90f, 90f, 90f);

        
        float winDistance = 100;
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            float distTemp = Mathf.Sqrt(Mathf.Pow(enemy.transform.position.x - transform.position.x, 2)+Mathf.Pow(enemy.transform.position.z - transform.position.z, 2));
            if(distTemp<winDistance) {
                enemyToFireAt = enemy;
            }
        }

        xDiff = enemyToFireAt.transform.position.x-GameObject.Find("Player").transform.position.x;
        zDiff = enemyToFireAt.transform.position.z-GameObject.Find("Player").transform.position.z;

        lengthA = Mathf.Abs(xDiff);
        lengthC = Mathf.Abs(zDiff);
        lengthB = Mathf.Sqrt(Mathf.Pow(lengthA, 2) + Mathf.Pow(lengthC, 2));
        theta = Mathf.Acos((Mathf.Pow(lengthA, 2) + Mathf.Pow(lengthB, 2) - Mathf.Pow(lengthC, 2))/(2*lengthA*lengthB));
        // Debug.Log(theta* Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
        rb.AddForce(new Vector3(xDiff, 0f, zDiff) * .2f * Time.fixedDeltaTime, ForceMode.VelocityChange);
        // gameObject.transform.LookAt(enemyToFireAt.gameObject.transform);
        // Quaternion rotation = Quaternion.LookRotation (enemyToFireAt.transform.position - transform.position, transform.TransformDirection(Vector3.up));

        Quaternion rot = Quaternion.Euler(90f,  theta* Mathf.Rad2Deg, 90f);
        transform.rotation = rot;

        rpgDamage = GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel*30f;
        rpgRadius = GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel*5f;

        if(GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel >= 5) {
            GameObject.Find("GAME").GetComponent<MainUIScript>().rpgLevel = 5;
        }

    }

    public GameObject prefabExplosive;

    public float rpgDamage = 30f;
    public float rpgRadius = 5f;

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<EnemyCombat>().TakeDamage(rpgDamage);

            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                // if distance between every enemy and this enemy is <= 5, take 50 damage
                float distTemp = Mathf.Sqrt(Mathf.Pow(enemy.transform.position.x - col.gameObject.transform.position.x, 2)+Mathf.Pow(enemy.transform.position.z - col.gameObject.transform.position.z, 2));
                if(distTemp<rpgRadius) {
                    enemy.GetComponent<EnemyCombat>().TakeDamage(rpgDamage);
                }
            }

            GameObject booom = Instantiate(prefabExplosive, transform);
            booom.gameObject.transform.parent = null;
            Destroy(booom.gameObject, 2f);
            Destroy(gameObject);
        }
    }
}
