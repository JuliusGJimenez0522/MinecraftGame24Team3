using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour 
{
	public int dirt = 0;
	public int wood = 0;
	public int sand = 0;
	public int stone = 0;
	public int pork = 0;
	public int chicken = 0;

	//singleton implmentation
//	private static InventoryManager instance;
//	public static  InventoryManager Instance
//	{
//		get
//		{
//			if(instance == null)
//			{
//				instance = this;
//			}
//			return instance;
//		}
//	}

	void Start () 
	{
	
	}

	void Update () 
	{

	}

	public void SetDirt()
	{
		dirt = dirt + 1;
	}
	public void SetWood()
	{
		wood = wood + 1;
	}
	public void SetSand()
	{
		sand = sand + 1;
	}
	public void SetStone()
	{
		stone = stone + 1;
	}
	public void SetPork()
	{
		pork = pork + 1;
	}
	public void SetChicken()
	{
		chicken = chicken + 1;
	}
}
