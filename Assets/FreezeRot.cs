using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.Euler(60f, 60f, 0f);
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x - 23f, GameObject.Find("Player").transform.position.y + 43f, GameObject.Find("Player").transform.position.z);
    }
}
