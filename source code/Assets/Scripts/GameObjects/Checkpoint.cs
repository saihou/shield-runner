using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour 
{

	private float rotateSpeed = 80;
	private GameObject mgr;

	// Use this for initialization
	void Start () 
	{
		mgr = GameObject.Find ("GameManager") as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rotate ();
	}

	void Rotate ()
	{
		Vector3 rotateVector = new Vector3 (0.0f, rotateSpeed, 0.0f);
		transform.Rotate (rotateVector * Time.deltaTime, Space.World);
	}

	public void Destroy()
	{
		Destroy (gameObject);
		mgr.GetComponent<GameManager>().Win ();
	}
}
