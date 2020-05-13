using UnityEngine;

public class FollowPlayer : MonoBehaviour {

  public Transform player;

    void Update () {
      transform.position = player.position;
    }

}
