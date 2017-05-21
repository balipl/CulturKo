using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour {

    public Button playButton;
    public Toggle t1, t2, t3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((t1.isOn == true) && (t2.isOn == true) && (t3.isOn == true))
        {
            playButton.interactable = true;
        }
        else playButton.interactable = false;
	}
}
