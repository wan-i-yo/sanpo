using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnViewPoint : MonoBehaviour {
    private Toggle tgl;
    public GameObject targetChar;
    public GameObject targetCamera;
    private static Vector3 prePos;

    // Use this for initialization
    void Start()
    {
        tgl = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeToggle()
    {
        Vector3 cameraPos = targetCamera.transform.position;
        Vector3 targetPos = targetChar.transform.position;
        prePos = cameraPos;

        /* isOn == trueならパネルを表示する */
        if (tgl.isOn == true)
        {
            cameraPos = targetPos;
            cameraPos.y = targetPos.y + 10.0f;
            targetCamera.transform.position = cameraPos;
            /* isOn == falseならパネルを非表示にする */
        }
        else
        {
            targetCamera.transform.position = prePos;
        }
    }
}
