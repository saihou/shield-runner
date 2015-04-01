using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Animator anim;
	private GameObject player;
	private GameObject canvas;
	private GameObject [] enemies;

	// Use this for initialization
	void Start () 
	{
		player  = GameObject.Find ("player");
		canvas  = GameObject.Find ("Canvas");
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		anim    = canvas.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
		{
			Lose ();
		}
	}

	public void Lose()
	{
		GameOver();
	}

	public void Win()
	{
		GameOver();
	}

	void GameOver()
	{
		anim.SetTrigger("GameOver");
		RemoveObjectsFromScene ();
	}

	void RemoveObjectsFromScene ()
	{
		Destroy (player);
		for (int i = 0; i < enemies.Length; i++) {
			Destroy (enemies [i]);
		}
	}

	public void Restart()
	{
		Application.LoadLevel ( Application.loadedLevel );
	}
}
