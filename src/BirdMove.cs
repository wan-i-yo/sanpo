using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour {
    // 中心点
    public Transform target;
    // 回転速度
    public float rotate_speed;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
//        transform.LookAt(target);
        Vector3 axis = transform.TransformDirection(Vector3.up);
        transform.RotateAround(target.position, axis, rotate_speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime/2, Space.World);
    }
}
