using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour {

	private int score = 100;
	private GameplayManager gameplayManager;

	private bool hasCollided = false;
	//public GameObject house;
	public GameObject player;
	public GameObject missile;
	public GameObject house;


	void Awake(){
		gameplayManager = GameObject.FindObjectOfType<GameplayManager> ();
	}


  public void OnTriggerEnter(Collider collision){


		if (collision.gameObject.CompareTag("putin") || collision.gameObject.tag == "projectile") {
			Destroy(house, 4f);
				gameplayManager.UpdateScore(score);
				Destroy(this.gameObject, .01f);
		}
  }

}
