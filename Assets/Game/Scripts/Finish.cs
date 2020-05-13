using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    private void OnTriggerEnter(Collider collision){
        if (collision.GetComponent<Collider>().CompareTag("Player") || collision.GetComponent<Collider>().CompareTag("putin")){
            //Debug.Log("shmoopdyshmoop");
            FindObjectOfType<TimeManager>().RestoreTime();
            SceneManager.LoadScene("End Screen");
        }
    }
}
