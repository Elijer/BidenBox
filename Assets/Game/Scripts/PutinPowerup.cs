using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutinPowerup : MonoBehaviour
{

    public GameObject Biden;
    public GameObject BidenCam;

    public GameObject Putin;
    public GameObject outerPutin;
    public GameObject PutinCam;

    //public GameObject ps;
    //public Transform psRig;
    public float timeout = 100f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
     transform.Rotate(0.0f, 1.0f, 0.0f);
    }

    void OnTriggerEnter(Collider collision){
        if (collision.GetComponent<Collider>().CompareTag("Player")){
            Debug.Log("trigger entered");
            //GameObject deathExplosion = Instantiate(ps, transform.position, Quaternion.identity);

            //CentralData.lastSeenAt = Biden.GetComponent<Transform>().position;
            //CentralData.lastSpeed = Biden.GetComponent<Rigidbody>().velocity;
            outerPutin.GetComponent<Transform>().position = Biden.GetComponent<Transform>().position;
            outerPutin.GetComponent<Rigidbody>().velocity = Biden.GetComponent<Rigidbody>().velocity;

                Biden.SetActive(false);
                BidenCam.SetActive(false);
                
                Putin.SetActive(true);
                PutinCam.SetActive(true);
            
            //CentralData.lastSeenAt = Biden.position;
            //CentralData.lastSpeed = BidenRB.velocity;

            CentralData.putinMode = true;
            FindObjectOfType<GameplayManager>().darkPrince(true);
            Invoke("PutinModeTimeout", timeout);
        }
	}

    void PutinModeTimeout(){

        Biden.GetComponent<Transform>().position = outerPutin.GetComponent<Transform>().position;
        Biden.GetComponent<Rigidbody>().velocity = outerPutin.GetComponent<Rigidbody>().velocity;

        Biden.SetActive(true);
        BidenCam.SetActive(true);
                
        Putin.SetActive(false);
        PutinCam.SetActive(false);

        CentralData.putinMode = false;

        FindObjectOfType<GameplayManager>().darkPrince(false);
    }
}
