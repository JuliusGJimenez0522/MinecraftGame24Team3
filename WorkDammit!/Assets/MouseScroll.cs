using UnityEngine;
using System.Collections;

public class MouseScroll : MonoBehaviour 
{

	// Mouse scroll wheel quickbar slection, but without the quickbar part...

	// slots contols the mouse wheel scrolling, if the mouse moves slots increases slightly before reverting to 0, and decreases if the mouse scrolls down
	// this affects the position variable, 1 is added or taken away from it every time slots detects the mouse wheel moving.
	// This is a poor implamentation cause its just a bunch of if statements, and on 0 nothing happens. However, it works and the 0 thing isnt even noticable because the mouse wheel moves so much.
	public float slots = 0.0f;
	public int position = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Detects if the mouse is scrolling up or down.
		// scroll up
		slots = Input.GetAxis("Mouse ScrollWheel");
		if (slots > 0f)
		{
			position = position + 1;
			//print (position);
			//print ("up");
		}

		// scroll down
		else if (slots < 0f)
		{
			position = position - 1;

			//print ("down");s

		}


		// Ok now for my poor but functional implementation of the nine part item slot detection...

		//1
			if (position == 1 || position == -9) 
		{
			print ("Sword Selected!");

			// Put code here!
		}

		//2
			else if ( position == 2  || position == -8)
			{
				print ("Pickaxe Selected!");
				
				// Put code here!
			}
		//3
			  else if( position == 3  || position == -7)
			{
				print ("Torch Selected!");
				
				// Put code here!
			}
		//4
			else if( position == 4  || position == -6)
			{
				print ("Wood Selected!");
				
				// Put code here!
			}
		//5
			else if( position == 5  || position == -5)
			{
				print ("Stone Selected!");
				
				// Put code here!
			}
		
		//6
			else if( position == 6  || position == -4)
			{
				print ("Dirt Selected!");
				
				// Put code here!
			}
		//7
			else if( position == 7  || position == -3)
			{
				print ("Pork Selected!");
				
				// Put code here!
			}
		//8
			else if( position == 8  || position == -2)
			{
				print (" Chicken Selected!");
				
				// Put code here!
			}
		//9
			else if( position == 9  || position == -1)
			{
				print ("PINEAPPLES Selected!");
				
				// Put code here!
			}


		//reset, dont put any code in these!

			else if( position >= 10 )
			{
				print ("resetting");
				
				position = 1;
			}
			
			else  if (  position <= -10 )
			{
				print ("resetting");
				
				position = -1;
			}

	}
}
