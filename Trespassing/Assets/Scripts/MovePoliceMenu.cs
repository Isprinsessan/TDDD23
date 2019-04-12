using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoliceMenu : MonoBehaviour {

    public GameObject huntobj;
    private Vector3 moveDirection = Vector3.zero;
    float speed;
    float gravity;
    CharacterController controller;


	// Use this for initialization
	void Start () {
        speed = 4;
        gravity = 20.0F;

        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(huntobj.transform.position.x, transform.position.y, huntobj.transform.position.z));
        moveDirection = Vector3.forward;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;



        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
