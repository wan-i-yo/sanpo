using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 拾い物
// GameビューにてSceneビューのようなカメラの動きをマウス操作によって実現する
[RequireComponent(typeof(Camera))]
public class SceneViewCamera : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10f)]
    private float wheelSpeed = 1.0f;

    [SerializeField, Range(0.1f, 10f)]
    private float moveSpeed = 0.3f;

    [SerializeField, Range(0.1f, 10f)]
    private float rotateSpeed = 0.3f;

    private Vector3 preMousePos;

    private Slider zoom_slider;

    public GameObject target;
    private Vector3 cameraPos;      //後でconfigにセーブする
    private Vector3 targetPos;      //後でconfigにセーブする
    private float zoom = -10.0f;    //後でconfigにセーブする
    private float height = 5.0f;    //後でconfigにセーブする

    [SerializeField]
    private GameObject bgmSld;
    [SerializeField]
    private GameObject fsSld;
    [SerializeField]
    private GameObject wsSld;
    [SerializeField]
    private GameObject birdSld;
    [SerializeField]
    private GameObject CamZoomSld;
    [SerializeField]
    private GameObject CamHeightSld;


    private void Start()
    {
        Slider bgmVal = bgmSld.GetComponent<Slider>();
        Slider fsVal = fsSld.GetComponent<Slider>();
        Slider wsVal = wsSld.GetComponent<Slider>();
        Slider birdVal = birdSld.GetComponent<Slider>();
        bgmVal.value = -80.0f;
        fsVal.value = -20.0f;
        wsVal.value = -20.0f;
        birdVal.value = -20.0f;

        Slider CamZmVal = CamZoomSld.GetComponent<Slider>();
        Slider CamHgtVal = CamHeightSld.GetComponent<Slider>();
        CamZmVal.value = -10.0f;
        CamHgtVal.value = 5.0f;
        cameraPos = transform.position;
        targetPos = target.transform.position;
        this.zoom_slider = GetComponent<Slider>();
        MouseWheel(zoom);
    }

    private void Update()
    {
        MouseUpdate();
        targetPos = target.transform.position;
        cameraPos = targetPos;
        cameraPos += transform.forward * zoom;
        cameraPos.y = targetPos.y + height;
        transform.position = cameraPos;
        //        Debug.Log("targetPos:"+ targetPos);
        AroundTheTarget();
        return;
    }

    public void SetZoom(float value)
    {
        zoom = value;
    }

    public void SetCamHeight(float value)
    {
        height = value;
    }

    private void MouseUpdate()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f)
            MouseWheel(scrollWheel);

        if (Input.GetMouseButtonDown(0) ||
           Input.GetMouseButtonDown(1) ||
           Input.GetMouseButtonDown(2))
            preMousePos = Input.mousePosition;

        MouseDrag(Input.mousePosition);
    }

    private void MouseWheel(float delta)
    {
        targetPos = target.transform.position;
        cameraPos = targetPos + transform.forward * delta;
        transform.position = cameraPos;
        return;
    }

    private void MouseDrag(Vector3 mousePos)
    {
        Vector3 diff = mousePos - preMousePos;

        if (diff.magnitude < Vector3.kEpsilon)
            return;

        // MouseButton(1)が右？(2)がトラックホイール？
        if (Input.GetMouseButton(2))
            transform.Translate(-diff * Time.deltaTime * moveSpeed);
        else if (Input.GetMouseButton(1))
            CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);

        preMousePos = mousePos;
    }

    private void SetCameraHeight(float value) {
        transform.Translate(Vector3.up * value * Time.deltaTime);
    }

    public void CameraRotate(Vector2 angle)
    {
        transform.RotateAround(transform.position, transform.right, angle.x);
        transform.RotateAround(transform.position, Vector3.up, angle.y);
    }

    private void AroundTheTarget() {
        float rotateX = 0.0f;
        float rotateY = 0.0f;

        // 十字キーで首を左右に回す
        if (Input.GetKey(KeyCode.RightArrow)){rotateX = 0.5f;}
        if (Input.GetKey(KeyCode.LeftArrow)){rotateX = -0.5f;}
        if (Input.GetKey(KeyCode.UpArrow)){rotateY = 0.2f;}
        if (Input.GetKey(KeyCode.DownArrow)){rotateY = -0.2f;}
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, rotateX * Time.deltaTime * 200f);
        // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
        transform.RotateAround(targetPos, transform.right, rotateY * Time.deltaTime * 200f);
    }
}
