using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	public int Invert;
	public int Movement = 1;
	public float speedBoost = 2.5f;
	public float currentSpeed = 0.0f;
	// Use this for initialization
	void Start () 
	{
		Invert = 1;
		Movement = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.z < -20.0f) 
		{
			Start ();
			transform.position = Vector3.zero;
			GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
		}
		if (transform.position.z > 20.0f) 
		{
			Start ();
			transform.position = Vector3.zero;
			GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
		}
		if (Input.GetKeyDown (KeyCode.Space))
			GetComponent<Rigidbody>().velocity = new Vector3 (10.0f, 0.0f, 5.0f);
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "Wall") 
		{
			Invert = Invert * -1;
			GetComponent<Rigidbody>().velocity = new Vector3 (10.0f * Invert * speedBoost, 0.0f, 5.0f * Movement * speedBoost);
		}
		else if (other.gameObject.name == "Player1") 
		{
			Movement = 1;
			GetComponent<Rigidbody>().velocity = new Vector3 (10.0f * Invert * speedBoost, 0.0f, 5.0f * speedBoost);
		}
		else if (other.gameObject.name == "Player2") 
		{
			Movement = -1;
			GetComponent<Rigidbody>().velocity = new Vector3 (10.0f * Invert * speedBoost, 0.0f, -5.0f * speedBoost);
		}
	}
	void FixedUpdate ()
	{
		currentSpeed = Vector3.Magnitude (GetComponent<Rigidbody> ().velocity);
	}
}
