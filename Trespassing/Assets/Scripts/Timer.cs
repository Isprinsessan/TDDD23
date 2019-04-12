using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer;
    Text timerText;
    public float rounded;
    public Movement MovementScript;
	// Use this for initialization
	void Start () {
        rounded = 0.0f;
        timer = 0.0f;
        //Hittar textfältet och texten som ska ändras
        timerText = GameObject.Find("TimerText").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        //Hämtar tiden
        if (!MovementScript.StopBool)
        {
            timer += Time.deltaTime;

            //Avrundar till 2 decimaler
            rounded = Mathf.Round(timer * 10.0f) / 10.0f;

            //Uppdaterar texten
            timerText.text = "" + rounded;
        }
	}
}
