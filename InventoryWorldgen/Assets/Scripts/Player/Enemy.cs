using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour 
{
	public float timer = 0.0f; 
	public bool hit = false;
	// Use this for initialization
	void Start () 
	{
		hit = false; 
	}
	
	// Update is called once per frame
	void Update () 
	{		
		if (hit == true) 
		{
			timer += Time.deltaTime; 
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (1500000000000000.0f, other.gameObject.transform.position, 10.0f, 3.0F);
			print ("Something"); 
		}
	}
}