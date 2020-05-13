using UnityEngine;

public class FollowPlayerOrPutin : MonoBehaviour {

  public GameObject player;
  public GameObject putin;

    void Update () {
        if (player.activeSelf == true){
            transform.position = player.GetComponent<Transform>().position;
        } else if (putin.activeSelf == true){
            transform.position = putin.GetComponent<Transform>().position;
        }
    }

}
