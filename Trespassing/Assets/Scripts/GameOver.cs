using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    Animator anim;
    GameObject gameoverText;
    /*
    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.collider.gameObject.tag == "GameOver")
        {

            anim = gameObject.GetComponent<Animator>();
            //Stänger av runninganimationen
            anim.SetBool("isRunning", false);
            //Stänger av movementscriptet så att spelaren inte kan röra sig
            GetComponent<Movement>().enabled = false;
            //Spelar upp deathanimationen
            anim.SetBool("isDead", true);

           // gameoverText = GameObject.Find("GameOverText");
           // gameoverText.GetComponent<Text>().enabled = true; 
 
            
        }
    }
    */

}
