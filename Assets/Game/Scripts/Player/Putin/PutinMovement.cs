using UnityEngine;
using System.Collections;

public class PutinMovement : MonoBehaviour {


	[Header ("Player Object")]
	public Rigidbody rb;
	public Transform playerLocation;
	public GameObject ps;
	public int f = 10000;
	public int sidef = 15;
	public float maxSpeed = 100f;
	public int jumpForce = 300;

	private bool PlayerIsAlive = true;
	private bool hasJumped = false;
	private bool beginMovement = false;

	private float currentVelocity;


  void Start(){
	FindObjectOfType<GameplayManager>().GameVolume();

	Invoke("DelayMovement", 0.4f);

  }

  void DelayMovement(){
	beginMovement = true;
  }

  void Update(){
	var pos = transform.position;
    pos.x =  Mathf.Clamp(transform.position.x, -21.0f, 21.0f);
    transform.position = pos;
  }

  void FixedUpdate(){

		// Limiting Speed
		if (PlayerIsAlive == true){
			if(rb.velocity.magnitude > maxSpeed && rb.position.y < 3){
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}

			// Controls

			if (Input.GetKeyDown("space")){
				if (hasJumped == false){
					Debug.Log("Jumped!");
					rb.AddForce(0, jumpForce, 0);
					hasJumped = true;
				}
			}

			//Forward auto
			//rb.AddForce(0, 0, f * Time.deltaTime);

			if (Input.GetKey("w")){ //left
				rb.AddForce(0, 0, f * Time.deltaTime);
			}

			if (Input.GetKey("a")){ //left
				rb.AddForce(-sidef * Time.deltaTime*2, 0, 0, ForceMode.VelocityChange);
			}

			if (Input.GetKey("d")){ //right
				rb.AddForce(sidef * Time.deltaTime*2, 0, 0, ForceMode.VelocityChange);
			}

			/*if (Input.GetKey("s")){ //back
				rb.AddForce(0, 0, -f * Time.deltaTime);
			}*/

			if(rb.position.y < -2f || rb.position.x < -200f || rb.position.x > 200f || rb.position.y > 200f){
				FindObjectOfType<GameplayManager>().EndGame();
			}
		}
	}

	void OnTriggerEnter(Collider collision){
		FindObjectOfType<AudioManager>().PlayRandom();
	}

	void OnCollisionEnter(Collision collision){

				//Obstacle Collision Stuff
				if (collision.collider.tag == "player" && CentralData.putinMode == true){


					ContactPoint contact = collision.contacts[0];
					GameObject deathExplosion = Instantiate(ps, playerLocation.position, Quaternion.identity);
				
					//Invoke("CreateCollisionParticles", 0.02f);

					//rb.AddTorque(Vector3.forward * .1f, ForceMode.VelocityChange);
					//int r1 = UnityEngine.Random.Range(2000, -2000);
					//int r2 = UnityEngine.Random.Range(-29990, -30000);

					rb.AddTorque(Vector3.left * 300000f);
					rb.AddTorque(Vector3.down * 300000f);

					//PlayerIsAlive = false; //Another Game Over event is when player falls off the Edge


					//FindObjectOfType<GameplayManager>().EndGame();
					//Debug.Log("Player Died!");
				} else if (collision.collider.tag == "ground"){
					hasJumped = false;
				}
			}
	}
