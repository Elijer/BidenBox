using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	[Header ("Player Object")]
	public Rigidbody rb;
	public Transform playerLocation;
	public GameObject ps;
	public GameObject ps2;
	public int f = 10000;
	public int sidef = 15;
	public float maxSpeed = 100f;
	public int jumpForce = 300;

	public float jumpGravity = 8;

	private bool PlayerIsAlive = true;
	private bool hasJumped = false;
	private bool beginMovement = false;

	private float currentVelocity;

  void Start(){
	FindObjectOfType<GameplayManager>().GameVolume();
	CentralData.putinMode = false;

	Invoke("DelayMovement", 0.4f);

  }

  void DelayMovement(){
	beginMovement = true;
  }

  void Update(){
	//CentralData.v = rb.velocity.z;
	//currentVelocity = rb.velocity.z;
	//Debug.Log(currentVelocity);
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
			rb.AddForce(0, 0, f * Time.deltaTime);

			/*if (Input.GetKey("w")){ // manual auto
				rb.AddForce(0, 0, f * Time.deltaTime);
			}*/

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

		if (hasJumped == true){
			rb.AddForce(0, -jumpGravity, 0);
		}
	}

	void OnTriggerEnter(Collider collision){
		FindObjectOfType<AudioManager>().PlayRandom();
	}

	void OnCollisionEnter(Collision collision){

				//Obstacle Collision Stuff
				if (collision.collider.tag == "obstacle" && CentralData.putinMode == false){


					ContactPoint contact = collision.contacts[0];
					GameObject deathExplosion = Instantiate(ps, playerLocation.position, Quaternion.identity);
					GameObject deathExplosion2 = Instantiate(ps2, playerLocation.position, Quaternion.identity);
					//Invoke("CreateCollisionParticles", 0.02f);

					//rb.AddTorque(Vector3.forward * .1f, ForceMode.VelocityChange);
					//int r1 = UnityEngine.Random.Range(2000, -2000);
					//int r2 = UnityEngine.Random.Range(-29990, -30000);

					rb.AddTorque(Vector3.left * 300000f);
					rb.AddTorque(Vector3.down * 300000f);

					FaceSwitch biden = this.GetComponent<FaceSwitch>();
      				biden.ChangeFace(2);

					PlayerIsAlive = false; //Another Game Over event is when player falls off the Edge


					FindObjectOfType<GameplayManager>().EndGame();
					Debug.Log("Player Died!");
				} else if (collision.collider.tag == "ground"){
					hasJumped = false;
				}
			}
	}
