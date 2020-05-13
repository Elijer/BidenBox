using System.Collections;
using UnityEngine;

public class FaceSwitch : MonoBehaviour {

    [Header ("Set Player GameObject")]
    public GameObject player;

    [Header ("Faces")]
    public Material face1;
    public Material face2;

    public void ChangeFace(int face){
      if (face == 1){
        player.GetComponent<MeshRenderer> ().material = face1;
      } else if (face == 2){
        //player.GetComponent<MeshRenderer> ().material = face2;
        StartCoroutine(FaceCoroutine(.5f, face2, face1));
        //Invoke("FaceSwitch", 0.5f);
      }
    }

    private IEnumerator FaceCoroutine(float t, Material face1, Material face2){
      player.GetComponent<MeshRenderer> ().material = face1;
      yield return new WaitForSeconds(t);
      player.GetComponent<MeshRenderer> ().material = face2;
    }
}
