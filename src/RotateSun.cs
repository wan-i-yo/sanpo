using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour {

    private Light sunlt;
	// Use this for initialization
	void Start () {
        sunlt = GetComponent<Light>();
        sunlt.intensity = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = transform.rotation * Quaternion.Euler(Time.deltaTime*10, 0, 0);
/*        if ( transform.rotation.x >= 0 && transform.rotation.x <= 180 ) {
            sunlt.intensity = 3.0f;
        }
        else {
            sunlt.intensity = 0.0f;
        }
*/    }
}
