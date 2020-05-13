using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour {

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
