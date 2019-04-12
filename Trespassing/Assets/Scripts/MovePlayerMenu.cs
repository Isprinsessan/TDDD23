using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerMenu : MonoBehaviour {


    public Transform[] positions;
    int NextPos;
    private Vector3 moveDirection = Vector3.zero;
    float speed;
    float gravity;

    CharacterController controller;

	// Use this for initialization
	void Start () {
        NextPos = 0;
        speed = 5;
        gravity = 20.0F;

        controller = gameObject.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(positions[NextPos].transform.position.x, transform.position.y, positions[NextPos].transform.position.z));
        moveDirection = Vector3.forward;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (Vector3.Distance(this.transform.position, positions[NextPos].transform.position) < 2.0f)
        {
            if(NextPos == positions.Length-1)
            {
                NextPos = 0;
            }
            else
            {
                NextPos += 1;
            }

        }


        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

		
	}
}
