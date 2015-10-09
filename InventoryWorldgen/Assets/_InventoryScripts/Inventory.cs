using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item> ();
	public List<Item> slots = new List<Item> ();

	private bool showInventory;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;


	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < (slotsX * slotsY); i++) 
		{
			slots.Add(new Item());
			inventory.Add (new Item());
		}

		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		AddItem (0);
		AddItem (1);
		AddItem (2);
		AddItem (3);
		AddItem (4);
		AddItem (5);
		AddItem (6);
		AddItem (7);
		AddItem (8);
		AddItem (9);
		AddItem (10);
		AddItem (11);

		//Debug Tools
		//print (InventoryContains(1));

		//RemoveItem (5);
	
		//inventory[0] = database.items [0];
		//inventory[1] = database.items [1];

	}
	void Update()
	{

	}
	// Update is called once per frame
	void OnGUI () 
	{
//		if (GUI.Button (new Rect (40, 400, 100, 40), "Save"))
//			SaveInventory ();
//		if (GUI.Button (new Rect (40, 450, 100, 40), "Load"))
//			LoadInventory ();
		tooltip = "";
		GUI.skin = skin;
		if (showInventory)
		{
			DrawInventory();
			if (showTooltip)
				GUI.Box (new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y,200, 200), tooltip);
			
		}
		if(draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}

		for (int i = 0; i < inventory.Count; i++)
		{
			GUI.Label(new Rect (10,i * 20,200,50), inventory[i].itemName);
		}
	}
	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for (int y = 0; y < slotsY; y++)
		{
			for (int x = 0; x < slotsX; x++)
			{
				Rect slotRect = new Rect(x * 70, y * 70, 50, 50);
				GUI.Box (slotRect, "", skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if (slots[i].itemName != null)
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if (slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				else
				{
					if (slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && draggingItem)
						{
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}

				}
				if (tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		}
	}
	string CreateTooltip(Item item)
	{
		tooltip = "<color=ffffff>" + item.itemName + "</color>\n\n" + item.itemDescribe;
		return tooltip;
	
	}

	void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory[i].itemId == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}

	public void AddItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory [i].itemName == null)
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if (database.items [j].itemId == id)
					{
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}

	bool InventoryContains(int id)
	{
		bool result = false;
		for (int i = 0; i < inventory.Count; i++) 
		{
			result = inventory [i].itemId == id;
			if (result)
			{
				break;
			}
		}
		return result;
	}

//	void SaveInventory()
//	{
//		for (int i = 0; i < inventory.Count; i++)
//		{
//			PlayerPrefs.SetInt("Inventory " + 1, inventory[i].itemId);
//		}
//	}
//	void LoadInventory()
//	{
//		for (int i = 0; i < inventory.Count; i++) 
//		{
//			inventory[i] = PlayerPrefs.GetInt("inventory " + 1, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
//		}
//	}

	public void OpenInventory()
	{
		showInventory = !showInventory;
	}

	public void InventoryList()
	{
		int count = inventory.Count;
	}

}
