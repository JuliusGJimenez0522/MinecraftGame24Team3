using UnityEngine;
using System.Collections;

public class Feeler : MonoBehaviour
{
  public bool bump;

  public Feeler() { }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject)
        {
            //print("bump");

            if (other.gameObject.tag != "Zombie")
            {
                bump = true;
            }



        }
    }

    void OnTriggerExit(Collider other)
    {


        if (other.gameObject)
        {

            if (other.gameObject.tag != "Zombie")
            {
                bump = false;
            }



        }
    }
}
