using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
        rb.AddForce(Vector3.forward * 2f * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<EnemyCombat>().TakeDamage(50f);
        }
    }
}
