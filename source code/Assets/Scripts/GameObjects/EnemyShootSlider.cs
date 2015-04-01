using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class EnemyShootSlider : MonoBehaviour 
{
	private EnemyShootCooldown cooldownScript;
	private Slider slider;

	// Use this for initialization
	void Start () 
	{
		cooldownScript = GetComponentInParent<EnemyShootCooldown>();
		slider         = this.gameObject.GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//cooldownValue is the computed value in the cooldownScript
		float cooldownValue = cooldownScript.GetCurrentCooldownValue();
		//cooldownTimer is the fixed value set in Unity
		float cooldownTimer = cooldownScript.GetCooldownTimer();
		float sliderValue   = processCooldownValue(cooldownValue, cooldownTimer);
		slider.value        = sliderValue;
	}

	/*
	 * parameters: 
	 * cooldownValue is a value less than cooldownTimer (can be negative)
	 * cooldownTimer is the fixed value set in Unity
	 * 
	 * postcondition:
	 * returns a float (with 4 decimal places) between 0 - 1
	 */
	float processCooldownValue (float cooldownValue, float cooldownTimer)
	{
		double processedValueForSlider = cooldownValue;
		processedValueForSlider       /= cooldownTimer;

		if (processedValueForSlider < 0)
		{
			processedValueForSlider = 0;
		}

		//round to 4 decimal places
		processedValueForSlider = Math.Round (processedValueForSlider, 4);
		return (float) processedValueForSlider;
	}
}
