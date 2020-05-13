using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windows : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
    }
}
