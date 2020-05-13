using UnityEngine;

public class CamSwitch : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;

    void Start() {// Start is called before the first frame update
		cam1.enabled = true;
		cam2.enabled = false;
    }

    void Update() {// Update is called once per frame
		if (Input.GetKeyDown("c")){
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}
    }
}
