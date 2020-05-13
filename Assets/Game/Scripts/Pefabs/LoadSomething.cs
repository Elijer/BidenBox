using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSomething : MonoBehaviour {
    
    private Transform player;

    public GameObject child;

    private float loadDistance = 2500f;
	private Vector3 p;
	private Vector3 h;

    public bool shouldDebug = false;

    private float loadStart;
    private float loadEnd;

	void Start(){
		//p = player.position;
        player = GameObject.Find("BidenPosition").GetComponent<Transform>();
		h = transform.position;
        p = player.position;
        child.SetActive(false);
        loadStart = h.z - loadDistance;
        loadEnd = h.z + 200f;
	}

	void Update(){
        p = player.position;

        if (shouldDebug == true){
            Debug.Log("p.z is " + p.z + " and h.z - loadDistance is " + loadStart);
        }

        if (p.z > loadStart) {
            child.SetActive(true);
        }
        
        if (p.z > loadEnd){
            child.SetActive(false);
        }
    }

}
