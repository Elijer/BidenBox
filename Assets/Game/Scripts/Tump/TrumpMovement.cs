using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpMovement : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject trump;
    public float sidef = 30f;
    public float farLeft  = -13f;
    public float farRight = 13f;
    private int farLeftInt =  -13;
    private int farRightInt =  13;
    //private float middle = 0f;
    private int direction = 1;

    private bool hit = false;

    public Material goingLeft;
    public Material goingRight;
    public Material mad;
    public Material stupid;

    // Start is called before the first frame update
    void Start()
    {
        //make starting position of trump random
        int randomInt = UnityEngine.Random.Range(farLeftInt, farRightInt);
        Vector3 randomX = new Vector3(randomInt,0,0);
        transform.position += randomX;
    }

    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "projectile"){
            hit = true;
        }
    }
    // Update is called once per frame
    void Update() {
        
        if (hit == false){
            if (direction == 1){
                if (transform.position.x < farRight){
                    trump.GetComponent<MeshRenderer> ().material = goingRight;
                    rb.AddForce(sidef * Time.deltaTime * direction, 0, 0, ForceMode.VelocityChange);
                } else {
                    rb.velocity = new Vector3(0,0,0);
                    direction = -1;
                }
            } else if (direction == -1){
                if (transform.position.x > farLeft){
                    trump.GetComponent<MeshRenderer> ().material = goingLeft;
                    rb.AddForce(sidef * Time.deltaTime * direction, 0, 0, ForceMode.VelocityChange);
                } else {
                    rb.velocity = new Vector3(0,0,0);
                    direction = 1;
                }
            }
        }
    }
}
