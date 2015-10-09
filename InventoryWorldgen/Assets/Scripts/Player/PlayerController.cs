using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
   
	Inventory inventory;
	int currentHealth;
    Rect crossHairRect;
    Texture crossHairTexture;

	float mouseSen = 5.0f;
	float verticalRotation = 1.0f;
	public float upDownRange = 60.0f;

	public bool inv = false;
	public bool grounded = true; 
	public float speed = 1.0f; 
	public float jumpForce = 300f;
	public float sprintSpeed = 10.0f;

	public float knockBack;
	public float damage = 5f;
	float timer;

	public int health = 8;
	// Use this for initialization
	void Start ()
	{
		inv = false;

        float crossHairSize = Screen.width * 0.1f;
        crossHairTexture = Resources.Load("Textures/CrossHair") as Texture;
        crossHairRect = new Rect(Screen.width / 2 - crossHairSize / 2, Screen.height / 2 - crossHairSize / 2, crossHairSize, crossHairSize);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

    void OnGUI()
    {
		GUI.TextField(new Rect(10, 10, 200, 20), "Health: " + health, 25);
        GUI.DrawTexture(crossHairRect, crossHairTexture);
    }

        // Update is called once per frame
        void Update () 
	{


		float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSen;
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSen;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			speed = sprintSpeed;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) 
		{
			speed = 5.0f; 
		}
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector3.forward * Time.deltaTime * speed); 
		}
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (Vector3.back * Time.deltaTime * speed); 
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector3.left * Time.deltaTime * speed); 
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate (Vector3.right * Time.deltaTime * speed); 
		}
		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			if(gameObject.GetComponent<Rigidbody> ().velocity.y < 300f)
				gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpForce);
			grounded = false; 
		}
		if (Input.GetMouseButtonDown(0)) 
		{

		}

	}
	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{			
			other.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (150.0f, other.gameObject.transform.position, 10.0f, 3.0F);
			print ("Something"); 
			health --;
			print (health);
		}
	

	}
}	



   



