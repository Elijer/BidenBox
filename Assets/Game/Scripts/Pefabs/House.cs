using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	public GameObject normal;
	public GameObject darkPrince;

	void Update(){

		if (CentralData.putinMode == false){
			darkPrince.SetActive(false);
			normal.SetActive(true);
		} else if (CentralData.putinMode == true){
			normal.SetActive(false);
			darkPrince.SetActive(true);
		}
	}

}
