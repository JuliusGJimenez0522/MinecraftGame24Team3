using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public string itemName;
	public int itemId;
	public string itemDescribe;
	public Texture2D itemIcon;
	public int itemPower;
	public int itemSpeed;
	public ItemType itemType;

	public enum ItemType
	{
		Weapon,
		Equipment,
		Consumable,
		Crafting,
		Block
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public Item(string name,int id, string describe)
	{

	}
}
