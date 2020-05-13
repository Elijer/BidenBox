using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

  public Rigidbody rb;
  public ParticleSystem dust;
  public GameObject dustObject;
  public float f = 4500;

  private bool hasCollided = false;
  private float playerVelocity;
  private GameObject[] players;
  private GameObject player;
  private Rigidbody playerRB;

  void start(){
    float turn = Input.GetAxis("Horizontal");
  }

  void OnCollisionEnter(Collision collision) {

    if (collision.gameObject != player && collision.gameObject.tag != "projectile" && collision.gameObject.tag != "ground") { 
      if (hasCollided == false){
        GameObject collisionDust = (GameObject)Instantiate(dustObject, rb.position, rb.rotation);
        Explosion explosion = collisionDust.GetComponent<Explosion>();

        if (explosion != null){
          explosion.Settle();
        }
      }
      Destroy(this.gameObject, .3f);
    }
  }

  public void SelfDestruct(float missileLifeSpan){
    Destroy(this.gameObject, missileLifeSpan);
  }

  public void Fire (float force){
    rb.AddTorque(Vector3.forward * .1f, ForceMode.VelocityChange);
    rb.AddTorque(Vector3.left * 0.2f, ForceMode.VelocityChange);
    rb.AddTorque(Vector3.down * .8f, ForceMode.VelocityChange);
  }

}
