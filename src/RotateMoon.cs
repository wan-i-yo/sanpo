using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour {

    private Light moonlt;
	// Use this for initialization
	void Start () {
        moonlt = GetComponent<Light>();
        moonlt.intensity = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = transform.rotation * Quaternion.Euler(Time.deltaTime*10, 0, 0);
        if ( transform.rotation.x <= 180 || transform.rotation.x >= 360 ) {
            moonlt.intensity = 1.0f;
        }
        else {
            moonlt.intensity = 0.0f;
        }
    }
}
