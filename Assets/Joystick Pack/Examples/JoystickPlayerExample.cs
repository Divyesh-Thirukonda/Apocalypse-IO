using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 150;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;


    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.left * variableJoystick.Horizontal;
        rb.AddForce(new Vector3(direction.z * speed * Time.fixedDeltaTime, 0f, direction.x * speed * Time.fixedDeltaTime), ForceMode.VelocityChange);

        float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle-90, 0f);
    }
}