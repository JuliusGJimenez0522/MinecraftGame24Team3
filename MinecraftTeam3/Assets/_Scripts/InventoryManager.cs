using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : MonoBehaviour 
{
	public int torchInventory = 0;
	public int woodInventory = 0;
	public int stoneInventory = 0;
	public int dirtInventory = 0;
	public int sandInventory = 0;

	public int porkFood = 0;
	public int chickenFood = 0;

	public Text swordInvText;
	public Text pickAxeInvText;
	public Text torchInvText;
	public Text woodInvText;
	public Text stoneInvText;
	public Text dirtInvText;
	public Text sandInvText;

	public Text porkInvText;
	public Text chickenInvText;


	// Use this for initialization
	void Start () 
	{
		SetCountText ();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(Input.GetKeyDown(KeyCode.Q))
//		{
//			Debug.Log("Q was Pressed");
//			woodInventory = woodInventory + 1;
//			Debug.Log("woodInventory = " + woodInventory);
//			SetCountText ();
//		}
//		if(Input.GetKeyDown(KeyCode.W))
//		{
//			Debug.Log("W was Pressed");
//			stoneInventory = stoneInventory + 1;
//			Debug.Log("stoneInventory = " + stoneInventory);
//			SetCountText ();
//		}
//		if(Input.GetKeyDown(KeyCode.E))
//		{
//			Debug.Log("E was Pressed");
//			dirtInventory = dirtInventory + 1;
//			Debug.Log("dirtInventory = " + dirtInventory);
//			SetCountText ();
//		}
//		if(Input.GetKeyDown(KeyCode.R))
//		{
//			Debug.Log("R was Pressed");
//			sandInventory = sandInventory + 1;
//			Debug.Log("sandInventory = " + sandInventory);
//			SetCountText ();
//		}
//		if(Input.GetKeyDown(KeyCode.T))
//		{
//			Debug.Log("T was Pressed");
//			porkFood = porkFood + 1;
//			Debug.Log("porkFood = " + porkFood);
//			SetCountText ();
//		}
//		if(Input.GetKeyDown(KeyCode.Y))
//		{
//			Debug.Log("Y was Pressed");
//			chickenFood = chickenFood + 1;
//			Debug.Log("chickenFood = " + chickenFood);
//			SetCountText ();
//		}
	}
	void SetCountText ()
	{
		swordInvText.text = "Sword";
		pickAxeInvText.text = "PickAxe";
		torchInvText.text = "Torch: " + torchInventory.ToString ();
		woodInvText.text = "Wood: " + woodInventory.ToString ();
		stoneInvText.text = "Stone: " + stoneInventory.ToString ();
		dirtInvText.text = "Dirt: " + dirtInventory.ToString ();
		sandInvText.text = "Sand: " + sandInventory.ToString ();

		porkInvText.text = "Bacon: " + porkFood.ToString ();
		chickenInvText.text = "Chicken: " + chickenFood.ToString ();

	}
	public void SetTorch ()
	{
		torchInventory = torchInventory + 1;
		SetCountText ();
	}

	public void SetDirt()
	{
		dirtInventory = dirtInventory + 1;
		SetCountText ();
	}
	public void SetWood()
	{
		woodInventory = woodInventory + 1;
		SetCountText ();
	}
	public void SetSand()
	{
		sandInventory = sandInventory + 1;
		SetCountText ();
	}
	public void SetStone()
	{
		stoneInventory = stoneInventory + 1;
		SetCountText ();
	}
	public void SetPork()
	{
		porkFood = porkFood + 1;
		SetCountText ();
	}
	public void SetChicken()
	{
		chickenFood = chickenFood + 1;
		SetCountText ();
	}
}
