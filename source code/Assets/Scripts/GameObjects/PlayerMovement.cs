using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour 
{
	protected CharacterController controller;
	protected float speed      = 8.0f;
	[SerializeField]
	protected float jumpHeight = 12.0f;

	private float gravity        = 30.0f;
	private string faceDirection = "right";
	private Vector3 moveDirection;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//character is not on the ground
		if (!controller.isGrounded)
		{
			transform.parent = null;
		}

		//character is on the ground
		if (controller.isGrounded)
		{
			//horizontal axis currently set to 'Left and Right Arrows'. change this in Unity Editor if needed
			moveDirection  = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
			moveDirection  = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			//jump button currently set to 'Up Arrow'. change this in Unity Editor if needed
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpHeight;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		UpdateFaceDirection ();
	}

	void UpdateFaceDirection()
	{
		float currentAxis = Input.GetAxis("Horizontal");

		if (currentAxis > 0)
		{
			faceDirection = "right";
		}
		else if (currentAxis < 0)
		{
			faceDirection = "left";
		} 
		else
		{
			//do nothing, continue facing the same direction as before
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "movingPlatform")
		{
			transform.parent = hit.gameObject.transform;
		}

		if (hit.gameObject.tag == "checkpoint")
		{
			//remove checkpoint from scene
			hit.gameObject.GetComponent<Checkpoint>().Destroy();
		}
	}

	//returns 1 if facing right, returns -1 if facing left
	public int getFace()
	{
		return ((faceDirection == "right") ? 1 : -1);
	}

}




