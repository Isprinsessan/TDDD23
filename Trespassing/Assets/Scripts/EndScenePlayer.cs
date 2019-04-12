using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndScenePlayer : MonoBehaviour {
    CharacterController controller;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Animator anim;
    public GameObject Camera1;
    public GameObject CameraOnPlayer;
    public GameObject Para;
    public GameObject Menu;
    bool JUMP;
    bool STOP;
    private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        JUMP = false;
        STOP = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!STOP)
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(0, 0, 1);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (JUMP)
                {
                    moveDirection.y = jumpSpeed;
                    JUMP = false;
                }
                anim.SetBool("isRunning", true);
                Para.gameObject.SetActive(false);


            }








            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

        }
		
	}
    public void DoStop()
    {
        anim.SetBool("isRunning", false);
        STOP = true;

    }
    
    public void DoJump()
    {
        anim.SetBool("isRunning", false);
        JUMP = true;

    }
    public void inAir()
    {
        gravity = 0.001f;
        anim.SetBool("isRunning", false);
        Para.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
        CameraOnPlayer.SetActive(true);
        Camera1.SetActive(false);
    }
}
