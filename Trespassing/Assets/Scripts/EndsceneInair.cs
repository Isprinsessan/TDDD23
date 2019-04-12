using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndsceneInair : MonoBehaviour {

   public EndScenePlayer endplayerScript;
	// Use this for initialization
	void Start () {

		
	}
    void OnTriggerEnter(Collider col)
    {
        endplayerScript.inAir();
    }
}
