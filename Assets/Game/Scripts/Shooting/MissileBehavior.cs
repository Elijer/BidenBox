using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour {

public Rigidbody player;

    void OnCollisionEnter(Collision collision) {
      if (collision.gameObject != player || collision.gameObject.tag != "projectile") {
      //Debug.Log("woah a collisionnnn");
      Destroy(this.gameObject, .01f);
      Debug.Log("Where is this?");
      }
    }

    public void SelfDestruct(float time){
      Destroy(this.gameObject, time);
    }
}
