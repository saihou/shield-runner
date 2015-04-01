using UnityEngine;
using System.Collections;
using System;

public class EnemyShootCooldown : MonoBehaviour
{
	//set in Unity
	public float cooldownTimer  = 5f;

	//a computed value that is only used for the UI slider value
	private float cooldownValue = 0f;
	private float timeStamp;
	private EnemyBehaviour enemyScript;
	private bool isOnCooldown = false;

	// Use this for initialization
	void Start ()
	{
		timeStamp   = Time.time + cooldownTimer;
		enemyScript = GetComponentInParent<EnemyBehaviour>();
	}

	// Update is called once per frame
	void Update ()
	{
		isOnCooldown = enemyScript.GetCooldownStatus();
		if (isOnCooldown)
		{
			cooldownValue = timeStamp - Time.time;

			if (timeStamp < Time.time)
			{
				timeStamp = Time.time + cooldownTimer;
				
				enemyScript.resetCooldown();
			}
		} 
		else 
		{
			//if not on cooldown, freeze the countdown
			timeStamp = Time.time;
		}
	}

	public float GetCurrentCooldownValue()
	{
		return cooldownValue;
	}

	public float GetCooldownTimer()
	{
		return cooldownTimer;
	}
}
