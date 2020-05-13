using UnityEngine;

public class FollowPlayerMissileEdition : MonoBehaviour {

  public Transform player;
  public float zoffset = 10f;
  private Vector3 offset;

    void Start(){
      offset = new Vector3(0, 0, zoffset);
    }

    void Update() {
    	transform.position = player.position + offset;
      
		// whenever we say 'transform' with a non-capital-'t', it refers to the transform of our CURRENT object.
    }

}
