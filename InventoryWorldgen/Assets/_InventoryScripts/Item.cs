using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public Inventory inventory;

	public string itemName;
	public int itemId;
	public string itemDescribe;
	public Texture2D itemIcon;
	public ItemType itemType;
	public int itemQuantity;
	public GameObject itemPrefab;

	public enum ItemType
	{
		WeaponEquip,
		Consumable,
		Crafting,
		Block
	}

	public Item(string name,int id, string describe, ItemType type, int quantity)
	{
		itemName = name;
		itemId = id;
		itemDescribe = describe;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/" + name);
		itemType = type;
		itemQuantity = quantity;
		itemPrefab = null;

	}
	public Item ()
	{

	}
}
