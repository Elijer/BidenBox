using UnityEngine;

public class Explosion : MonoBehaviour {

  void start(){
    Destroy(this.gameObject, 1f);
  }

  public void Settle(){
    Destroy(this.gameObject, 1f);
  }
}
