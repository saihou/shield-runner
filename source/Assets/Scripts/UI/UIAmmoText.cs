using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIAmmoText : MonoBehaviour 
{
	private GameObject player;
	private PlayerShield targetScript;
	private Text currentText;
	private const string AMMO_DESC = "Remaining : ";

	// Use this for initialization
	void Start () 
	{
		player       = GameObject.Find("player");
		targetScript = player.GetComponent<PlayerShield>();
		currentText  = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		int ammo = targetScript.GetAmmo();
		currentText.text = AMMO_DESC + ammo;
	}
}
