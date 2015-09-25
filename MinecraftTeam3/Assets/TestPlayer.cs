using UnityEngine;
using System.Collections;

public class TestPlayer : MonoBehaviour 
{
	public GameObject gameManager;

	public int dirtAmount;
	public int woodAmount;
	public int stoneAmount;
	public int sandAmount;
	public int porkAmount;
	public int chickenAmount;

	InventoryManager inventoryManager;
	
	void Start () 
	{
		inventoryManager = gameManager.GetComponent<InventoryManager> ();
	}

	void Update () 
	{
		dirtAmount = inventoryManager.dirtInventory;
		woodAmount = inventoryManager.woodInventory;
		stoneAmount = inventoryManager.stoneInventory;
		sandAmount = inventoryManager.sandInventory;
		porkAmount = inventoryManager.porkFood;
		chickenAmount = inventoryManager.chickenFood;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "dirt") 
		{
			inventoryManager.SetDirt();
		}
		if (other.gameObject.tag == "wood") 
		{
			inventoryManager.SetWood();
		}
		if (other.gameObject.tag == "stone") 
		{
			inventoryManager.SetStone();
		}
		if (other.gameObject.tag == "sand") 
		{
			inventoryManager.SetSand();
		}
		if (other.gameObject.tag == "pork") 
		{
			inventoryManager.SetPork();
		}
		if (other.gameObject.tag == "chicken") 
		{
			inventoryManager.SetChicken();
		}
	}
}
