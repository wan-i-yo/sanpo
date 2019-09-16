using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionToggle : MonoBehaviour {
    private Toggle tgl;
    private OptionToggle opt_tgl;

	// Use this for initialization
	void Start () {
        tgl = GetComponent<Toggle>();
        opt_tgl = GetComponent<OptionToggle>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void ChangeToggle() {
        Debug.Log("Toggleが変更されました");
        /* isOn == trueならパネルを表示する */
        if (tgl.isOn == true) {
//          GameObject.Find("OptionPanel").SetActive(true);
            GameObject.Find("OptionMenu").transform.Find("OptionPanel").gameObject.SetActive(true);
        /* isOn == falseならパネルを非表示にする */
        }
        else {
            GameObject.Find("OptionPanel").SetActive(false);
        }
    }
}
