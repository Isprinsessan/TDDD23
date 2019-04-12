using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    float speed;
    float jumpSpeed;
    float gravity;
    private Vector3 moveDirection = Vector3.zero;
    public float pushPower = 2.0f;
    float SideWayMove;
    float ForwardMove;
    CharacterController controller;
    public int NrOfBats;
    public int NrOfCoins;
    int MaxCoins;

    public Animator anim;

    public GameObject Baseballbat;

    public InGameMenu MenuScript;

    public bool StopBool;
	// Use this for initialization
	void Start () {
         speed = 6.0F;
         jumpSpeed = 8.0F;
         gravity = 20.0F;
         controller = gameObject.GetComponent<CharacterController>();
        SideWayMove = 0.0f;
        ForwardMove = 0.0f;
        anim = gameObject.GetComponent<Animator>();
        StopBool = false;
        MaxCoins = GameObject.Find("Coins").transform.childCount;
        GameObject.Find("AntalCoinsText").GetComponent<Text>().text = "" + NrOfCoins + "/" + MaxCoins;
    }
	
	// Update is called once per frame
	void Update () {
        if (!StopBool)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 90 * Time.deltaTime, 0); //90 degree/second
            SideWayMove = Input.GetAxis("SideWay");
            ForwardMove = Input.GetAxis("Vertical");
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(SideWayMove, 0, ForwardMove);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }

            if (Mathf.Abs(ForwardMove) > 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
           

        }


       

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
	}

    public void Die(){
        if (!StopBool)
        {
            StopBool = true;
            moveDirection *= 0;

            anim.SetBool("isRunning", false);
            MenuScript.ShowCrashMenu();
        }


    }
    public void LevelDone()
    {
        if (!StopBool)
        {
            StopBool = true;
            moveDirection *= 0;

            anim.SetBool("isRunning", false);
            MenuScript.ShowNextLvlMenu();
        }


    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "GameOver")
        {
            Die();
            anim.SetBool("isDead", true);


        }

        else if (hit.collider.gameObject.tag == "object")
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            //No rigidbody
            if (body == null || body.isKinematic)
            {
                return;
            }
            else if (hit.moveDirection.y < -0.3f) //We dont want to push objects below us
            {
                return;
            }

            //Calculate push direction from move direction
            //We only push objects to the sides, never upo and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            //If you know how fast you character is trying to move, 
            //Then you can also multiply the push velocity by that.
            //Apply the push
            body.velocity = pushDir * pushPower;
        }
        else if (hit.collider.gameObject.tag == "Finish")
        {
            LevelDone();
        }
        else if(hit.collider.gameObject.tag == "Collectable")
        {
            if (hit.collider.gameObject.name == "BaseballBat")
            {
            //    NrOfBats += 1;
                //Uppdatera texten med antalet 
//                GameObject.Find("AntalBatsText").GetComponent<Text>().text = "" + NrOfBats + "x";
                //Ta bort objektet
                Destroy(hit.collider.gameObject);

                Baseballbat.SetActive(true);


                //temp.SetActive(true);
            }
            else if (hit.collider.gameObject.name == "Coin")
            {
                
                NrOfCoins += 1;
                //print(NrOfCoins + "       upplockade   " + MaxCoins + "       Max coins   " + "  hejhejhej");
                //Uppdatera texten med antalet 
                GameObject.Find("AntalCoinsText").GetComponent<Text>().text = "" + NrOfCoins + "/" + MaxCoins;
                //Ta bort objektet
                Destroy(hit.collider.gameObject);

            }
        }

    }


}

