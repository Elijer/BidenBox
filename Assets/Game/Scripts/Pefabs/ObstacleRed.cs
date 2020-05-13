using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRed : MonoBehaviour {

	public GameObject normal;
	public GameObject darkPrince;


    // Update is called once per frame
    void Update() {
        if (CentralData.putinMode == true){
            this.GetComponent<BoxCollider>().isTrigger = true;
            normal.SetActive(false);
			darkPrince.SetActive(true);
        } else {
            this.GetComponent<BoxCollider>().isTrigger = false;
            darkPrince.SetActive(false);
			normal.SetActive(true);
        }
    }
}
