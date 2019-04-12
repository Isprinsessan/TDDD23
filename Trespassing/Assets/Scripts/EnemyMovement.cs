using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    GameObject player;
    float MoveSpeed;
    float MaxDist;
    public GameObject Flashlight;


    float speed;
    float jumpSpeed;
    float gravity;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    public bool hunt;
    Animator animPolice;

    Movement PlayerMoveScript;

	// Use this for initialization
	void Start () {
        MaxDist = 10.0f;

        speed = 4.0F;
        gravity = 20.0F;
        controller = gameObject.GetComponent<CharacterController>();
        animPolice = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        PlayerMoveScript = player.GetComponent<Movement>();

	}
	
	// Update is called once per frame
	void Update () {
        if (hunt)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            animPolice.SetBool("isRunning", true);
            if (controller.isGrounded)
            {
                moveDirection = Vector3.forward;
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

            }

            if (Vector3.Distance(this.transform.position, player.transform.position) > MaxDist)
            {
                
                    hunt = false;
                    moveDirection *= 0;



            }


        }
        else
        {
            animPolice.SetBool("isRunning", false);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name == "Player"){
            PlayerMoveScript.Die();
            animPolice.SetBool("isRunning", false);
            animPolice.SetBool("isPunching",true);
            StartCoroutine(playDeadAnimation());

        }
    }

    public IEnumerator playDeadAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        PlayerMoveScript.anim.SetBool("isDead", true);
        yield break;
    }

  
}
