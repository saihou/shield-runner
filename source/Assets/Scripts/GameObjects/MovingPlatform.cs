using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour 
{
	public int patrolDistance       = 5;
	public int speed                = 2;
	public bool isUsedAsLift        = false;
	public bool isTriggeredByPlayer = false;
	public bool canMoveOnlyOnce     = false;

	//1 = platform moving towards end position, -1 = platform moving towards start position
	private int currentDir   = 1;
	private float currentPos = 0;

	//stores the vector that describes movement towards end position
	private Vector3 movementVectorOne = Vector3.right;
	//stores the vector that describes movement towards start position
	private Vector3 movementVectorTwo = Vector3.left;
	//targetPos stores the displacement of the start and end positions
	private int [] targetPos          = new int[2];
	private bool isReadyToMove        = false;

	//initialisation
	void Start () 
	{
		initialisePositions ();
		initialiseMovementVectors();

		//start moving immediately if not triggered by player
		if (!isTriggeredByPlayer)
		{
			startMoving();
		}
	}

	void FixedUpdate()
	{
		if (isTriggeredByPlayer)
		{
			bool isPlayerOnPlatform = (transform.GetChild(0).childCount > 0);
			if (isPlayerOnPlatform)
			{
				startMoving();
				isTriggeredByPlayer = false;
			}
		}

		if (isReadyToMove)
		{
			if (hasReachedEndPositions())
			{
				changeDir();
			}
			Move ();
		}
	}

	void initialisePositions ()
	{
		if (patrolDistance >= 0) 
		{
			//start position = current position
			targetPos [0] = 0;
			targetPos [1] = patrolDistance;
		}
		else 
		{
			//if negative patrol distance
			//treat platform as already moved to 'end position' and start from there
			currentDir    = -1;
			targetPos [0] = 0;
			targetPos [1] = -patrolDistance;
			currentPos    = targetPos [1];
		}
	}

	void initialiseMovementVectors()
	{
		//set appropriate movement vectors depending on platform type
		if (isUsedAsLift)
		{
			movementVectorOne = Vector3.up;
			movementVectorTwo = Vector3.down;
		}
		else
		{
			movementVectorOne = Vector3.right;
			movementVectorTwo = Vector3.left;
		}
	}

	bool hasReachedEndPositions()
	{
		//if exceeds end position and moving towards end position 
		// || exceed start position and moving towards start position
		return (   (currentPos > targetPos[1]) && (currentDir == 1)
		        || (currentPos < targetPos[0]) && (currentDir == -1));
	}

	void startMoving()
	{
		isReadyToMove = true;
	}

	void Move()
	{
		//move platform using the 2 movement vectors, depending on current direction
		Vector3 movement = (currentDir == 1) ? movementVectorOne : movementVectorTwo;
		movement *= speed;

		transform.Translate(movement * Time.deltaTime);
		UpdateCurrentPos (movement);
	}

	void UpdateCurrentPos (Vector3 movement)
	{
		//update current pos accordingly depending on direction of movement of platform
		currentPos += ((isUsedAsLift) ? movement.y : movement.x) 
			          * Time.deltaTime;
	}

	void changeDir() 
	{
		if (canMoveOnlyOnce)
		{
			//stop platform after reaching end position
			isReadyToMove = false;
		}
		currentDir = - currentDir;
	}
}
