using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyCombat : MonoBehaviour
{
    public float lookRadius = 100f;
    public Transform target;
    public NavMeshAgent agent;
    public Animator anim;
    public float enemyMaxHealth;
    public float enemyHealth = 50f;
    public float enemyDamage = 20f;
    public float enemyAttackRange = 3f;
    public float enemyAttackCooldown = .5f;
    public float attackTimer = 0;
    public const float locomationAnimationSmoothTime = .1f;
    public GameObject enemyDrop;
    GameObject Player;

    System.Random randDrop = new System.Random();
    

    void Start()
    {
        Player = GameObject.Find("Player");

        enemyMaxHealth = enemyHealth;
    }

    void faceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Update()
    {
        target = Player.transform;
        float SpeedPercent = agent.velocity.magnitude / agent.speed;
        
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance) {
                faceTarget();
            }
        }
        
        if (distance <= enemyAttackRange) {
            attackTimer += 1 * Time.deltaTime;
            if(attackTimer >= enemyAttackCooldown) {
                anim.SetFloat("SpeedPercent", 2);
                /*
                PlayerStats.PlayerHealth -= (20- (20*(PlayerStats.PlayerDefense/100))); CHANGE
                attackTimer = 0;
                if (PlayerStats.PlayerHealth <= 0) {
                    foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Shootable")) {
                        Destroy(fooObj);
                    }
        
                    foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Chest")) {
                        Destroy(fooObj);
                    }
        
                    PlayerArmor.playerArmor = PlayerArmor.Armors.none;
                    PlayerStats.RESET();
                    SceneManager.LoadScene(0);
                }
                */
            }
        } else {
            anim.SetFloat("SpeedPercent", SpeedPercent, locomationAnimationSmoothTime, Time.deltaTime);
            attackTimer += 1 * Time.deltaTime;
        }
    }

    public void TakeDamage (float damage) {
        enemyHealth -= damage;
        if (enemyHealth <= 0) {
            Die();
        }
    }

    public GameObject possiblity0;
    public GameObject possiblity1;
    public GameObject possiblity2;
    public GameObject possiblity3;
    

    public GameObject XPprefab;

    public void Die() {

        GameObject expee = Instantiate(XPprefab, transform);
        expee.gameObject.transform.parent = null;
        expee.gameObject.transform.localScale = .5f*(Vector3.zero + new Vector3(1, 1, 1));

        Destroy(this.gameObject);
        GameObject[] enemyDrops = {possiblity0, possiblity1, possiblity2, possiblity3};
        enemyDrop = enemyDrops[randDrop.Next(0,4)];
        if (enemyDrop != null) {
            GameObject go = Instantiate(enemyDrop, this.gameObject.transform);
            go.gameObject.transform.parent = null;
            if (go.gameObject.name == "getGun(Clone)") {go.transform.position += new Vector3(0, 50, 0);go.SetActive(true);}
            go.name = go.name.Replace("(Clone)", "");
            if (go.gameObject.name == "Potion") {go.transform.position += new Vector3(0, 1, 0);}
            
        }
        
        
    }
}