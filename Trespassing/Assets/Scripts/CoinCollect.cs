using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour {

    Text coinText;
    // Use this for initialization
	void Start () {
        coinText = GameObject.Find("AntalCoinsText").GetComponent<Text>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player") 
        {
            this.gameObject.SetActive(false);
            col.gameObject.GetComponent<Movement>().NrOfCoins +=1;

            coinText.text = "" + col.gameObject.GetComponent<Movement>().NrOfCoins + "/" + col.gameObject.GetComponent<Movement>().MaxCoins;
        }
    }
}
