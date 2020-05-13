using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{
    public Rigidbody rb;

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Return)){
            FindObjectOfType<GameplayManager>().StartGame();
        }

        rb.AddTorque(Vector3.forward * .6f * Time.deltaTime);
        rb.AddTorque(Vector3.left * 2f * Time.deltaTime);
        rb.AddTorque(Vector3.down * 1f * Time.deltaTime);
    }
}
