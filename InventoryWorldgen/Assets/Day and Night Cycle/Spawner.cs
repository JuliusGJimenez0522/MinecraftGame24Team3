using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    //Has a 50% chance every five seconds to spawn a random prefab that varies depending on whether it is day or night...
    // note that the spawn rotation may have to be changed later to get whatever it is spawning to spawn upright
    //also note that whatever it spawns should have gravity, which it should anyway for it to move around and fall off things to go down...

    //to use just plug in the spawned objects to the the days or nights arrays, make sure that the random range for which prefab is large enough to encompass them, and then manually place around the semi random but not really map.

     
      public float isActive = 0f; 

    // drag all day creatures here and add more as needed// public GameObject day1 = null;
     public GameObject[] days ;
      

      // drag all night creatures here and add more as needed                                                                            
      public GameObject[] nights;
     


    // for making this dumb script talk to the DayNightCycle script via roundabout but working methods....
      public bool nightSpawn;

    //To reset the spawner to active or inactive...
      public float resetSpawner = 0.0f;

      public int whichPrefab;

	
    
    
    // Use this for initialization
	void Start () 
    {
        isActive = Random.Range(-1.0F, 1.0F);
        
        

        // if the spawner is active, spawn stuff depending on whether it is day or night.
       if(isActive >= 0f)
       {
         if (nightSpawn == false)
         {
            // change rotation as necessary for it to be right side up...
            Instantiate(days[whichPrefab], transform.position, transform.rotation);
                    
         }

         if (nightSpawn == true)
            {
            // change rotation as necessary for it to be right side up...
                Instantiate(nights[whichPrefab], transform.position, transform.rotation);
                                                                               
         }
       }
	}
	
	// Update is called once per frame
	void Update () 
    {
       

        resetSpawner  += Time.deltaTime;

        nightSpawn = DayNightCycle.isNight;

        // change it to something higher than five for non testing purposes...
        if (resetSpawner >= 15f)
        {
            ChangePrefab();
            Start();
            resetSpawner = 0f;
        }
	}

    void ChangePrefab()
    {
        // for choosing which prefab in the list to use. If there are more day spawns than night spawns (or vice versa) a new random range will need to be made for whichever has more and the spawn scripts modified accordingly!
        whichPrefab = Random.Range(0, 2);
    }
}
