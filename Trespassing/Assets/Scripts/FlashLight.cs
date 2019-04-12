using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    // Use this for initialization
    public EnemyMovement EnemyMovScript;
	void Start () {
		
	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player") // this string is your newly created tag
        {
            EnemyMovScript.hunt = true;
        }
    }
}
