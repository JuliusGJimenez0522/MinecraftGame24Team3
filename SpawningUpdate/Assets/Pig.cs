using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour 
{
	public int startingHealth = 3;
	public int currentHealth;
	public float speed = 1.0f;

    //I really don't know what I'm doing here so im going to use weird methods to randomize the ai movement... which actually worked out at the end lol
    float timer = 0.0f;
    int randomDirection = 0;
    
    //for getting it to jump when they hit something in front of it without going off in some random direction or ALL OF THEM jumping if one does or floating off into the air (too often anyway...)
    float jumpTimer = 0.0f;
    bool jump = false;
    public GameObject FeelerBox = null;

    
	
    
    // Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
		
        
	}
	
	// Update is called once per frame
   void Update () 
	{
       // find the object the Feeler script is attached to and get the bump bool from it, then convert it to a variable here so this script can easily use it.
        Feeler feeler = FeelerBox.GetComponent<Feeler>();
        jump = feeler.bump;

       //two timers, one for normal random movement and one to tell it not to change direction in the middile of a jump.
        timer += Time.deltaTime;
        jumpTimer += Time.deltaTime;
		
        transform.Translate (Vector3.forward * Time.deltaTime * speed);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
       //if jump is true jump up in the direction it was going.
        if (jump == true)
        {
            jumpTimer = 0;
            timer = 0;
            transform.position += Vector3.up * 30 * Time.deltaTime;
            jump = false;
        }
       //change direction every six seconds
        if (timer >= 6)
        {
            RandomDirection();

            transform.Rotate(new Vector3(0, randomDirection, 0));
            timer = 0;
        }


	}


	void OnCollisionEnter (Collision other)
	{

        if (jumpTimer >= 0.5)
        {
            if (other.gameObject)
            {

                //call RandomDirection function
                RandomDirection();

                transform.Rotate(new Vector3(0, randomDirection, 0));
                //Debug.Log (other.gameObject);
                //transform.position = new Vector3 (0.1f, transform.position.y, transform.position.z);


            }
        }

        

        if (other.gameObject.tag == "Zombie")
        {
            timer = 0;
            transform.Rotate(new Vector3(0, 180, 0));
            currentHealth = currentHealth - 1;
        }
	}

   
    //Give me a new random direction every time this is called
    void RandomDirection()
    {
        randomDirection = Random.Range(30, 180);
    }


}
