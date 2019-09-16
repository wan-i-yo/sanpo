using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 鳥の動作制御
public class BirdMove : MonoBehaviour {

    public Transform target;    // 中心点
    public float rotate_speed;  // 回転速度

    // Use this for initialization
    void Start () {
		// 何もしない
	}

    // 対象の周囲を回転する
    void Update()
    {
        Vector3 axis = transform.TransformDirection(Vector3.up);
        transform.RotateAround(target.position, axis, rotate_speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime/2, Space.World);
    }
}
