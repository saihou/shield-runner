using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	[SerializeField]
	protected int maxHp = 10;
	
	protected int currentHp;
	
	// Getter
	public int CurrHP {	get	{ return currentHp; } }
	public int MaxHP {	get	{ return maxHp; } }
	public float FractionHP { get { return (float)(currentHp)/(float)(maxHp); } }
	
	void Start()
	{
		currentHp = maxHp;
	}
	
	public void Modify(int amount)
	{
		currentHp += amount;
		
		if (currentHp > maxHp)
		{
			currentHp = maxHp;
		}
		else if (currentHp <= 0)
		{
			Die();
		}
	}
	
	public void Set(int amount)
	{
		currentHp = amount;
		Modify (0); // run thru the checks in Modify()
	}
		
	public void Die()
	{
		Destroy(this.gameObject);
	}
}
