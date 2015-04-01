using UnityEngine;
using System.Collections;

public class WelcomeManager : MonoBehaviour 
{
	//Called when player clicks the Start Button
	public void StartGame()
	{
		Application.LoadLevel ("Main");
	}
}
