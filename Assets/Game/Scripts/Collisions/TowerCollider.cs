using UnityEngine;
using UnityEngine.UI;

public class TowerCollider : MonoBehaviour {

	public int score = 60;
	private GameplayManager gameplayManager;

	private bool hasCollided = false;
	public GameObject player;
	public GameObject missile;

	public GameObject normal;
	public GameObject darkPrince;


	void Awake(){
		gameplayManager = GameObject.FindObjectOfType<GameplayManager> ();
	}

	void Update(){
		if (CentralData.putinMode == false){
			darkPrince.SetActive(false);
			normal.SetActive(true);
		} else if (CentralData.putinMode == true){
			normal.SetActive(false);
			darkPrince.SetActive(true);
		}
	}


  public void OnTriggerEnter(Collider collision){

		if (collision.gameObject.CompareTag("projectile") || collision.gameObject.CompareTag("putin")) {
				gameplayManager.UpdateScore(score);
		}
  }

}
