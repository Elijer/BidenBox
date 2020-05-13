using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOuterPutin : MonoBehaviour
{
    public Transform outerPutin;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
        transform.Rotate(0.0f, 1.0f, 0.0f);
        transform.position = outerPutin.position;
    }
}
