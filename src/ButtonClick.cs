using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {
    private GameObject opt_panel;

    public void OnClick()
    {
        Debug.Log("Button click!");
        GameObject.Find("OptionPanel").SetActive(false);
    }

}
