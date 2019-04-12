using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneStop : MonoBehaviour {
    public EndScenePlayer endplayerScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {

        endplayerScript.DoStop();
    }
}
