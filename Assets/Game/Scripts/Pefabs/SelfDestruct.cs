using UnityEngine;

public class SelfDestruct : MonoBehaviour {

  void start(){
    Destroy(this.gameObject, 4f);
  }
}
