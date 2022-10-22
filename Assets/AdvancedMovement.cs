using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdvancedMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Camera cam;
	bool grounded;


    void Start() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;


    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && PlayerStats.PlayerStamina > 0) {
            PlayerStats.PlayerStamina -= 1 * Time.deltaTime;
            PlayerStats.PlayerSpeed = 10;
        } else {
            if (PlayerStats.PlayerStamina <= 3) {
                PlayerStats.PlayerStamina += (float).2 * Time.deltaTime;
            }
            PlayerStats.PlayerSpeed = 5;
        }

    }

    public void OnCollisionEnter (Collision collisionInfo) {

        if (collisionInfo.collider.tag == "Enemy") {
            
        }
        
    }

    void OnCollisionStay(Collision collision) {
        if(collision.collider.gameObject.layer == 8) {
            grounded = true;
        } else {
            grounded = false;
        }
    }
    void OnCollisionExit(Collision collision) {
        if(collision.collider.gameObject.layer == 8) {
            grounded = false;
        }
    }
    
}
