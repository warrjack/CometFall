using System; 							// For Squares and Square Rooots
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;					// For Text UI

public class PlayerController : MonoBehaviour
{
	public int currentPlanet = 0;			// Current planet referencing in array
 	public GameObject gameObject1;          // Reference to the first GameObject
    public GameObject gameObject2;          // Reference to the second GameObject
    private float speed = 4/2;				// Starting speed of orb
    public GameObject gl;					// Game Logic Empty Object
    private GameLogic gameLogic;			// Game Logic Script
    private int swingRight = 1;				// Go left or right (1 = right, -1 = left)
 
    private LineRenderer line;              // Line Renderer
    private Rigidbody2D rigidbody;			// Orb Rigidbody
    public ParticleSystem explosionPS;		// Death explostion partical system
    public ParticleSystem trailPS;			// Trail particle system

    public GameObject playerBody;			// Main player game object
   	public GameObject scoreTextObject;		// UI Scoreboard
   	private Text scoreText;					// UI Scoreboard text
    private bool buttonWasPressedInTick = false;	// Check if button was pressed during loop
    private bool stillAlive = true;			// Check if still alive
    public GameObject gameOverScreen;
 
     // Use this for initialization
     void Start () {
     	//Get Score Text
     	scoreText = scoreTextObject.GetComponent<Text>();

     	//Get Rigidbody
     	rigidbody = GetComponent<Rigidbody2D>();

     	//Game Logic handler
     	gameLogic = gl.GetComponent<GameLogic>();

        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        // Set the width of the Line Renderer
        line.SetWidth(0.05F, 0.05F);
        // Set the number of vertex fo the Line Renderer
        line.SetVertexCount(2);
     }
     
     // Update is called once per frame
     void Update () {
     	if (stillAlive)
     	{
     		speed += 0.1f*Time.deltaTime;
     		buttonWasPressedInTick = false;

     	}

     	//When right mouse button is down
     	if (Input.GetMouseButtonDown(0))
     	{
     		//Set connecting object to current planet in collection
     		gameObject2 = gameLogic.planetCollection[currentPlanet];

 			Vector3 targ = gameObject2.transform.position;
	        targ.z = 0f;

	        targ.x = targ.x - transform.position.x;
	        targ.y = targ.y - transform.position.y;
	        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

     		//Check if swinging left or right
	        if (gameObject2.transform.position.x > transform.position.x)
	        {
	          	swingRight = -1;
	            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	        }
	        else
	        {
	        	//Left
	           	swingRight = 1;
	            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
	        }     		
     	}

     	//While right mouse button is clicked
     	if (Input.GetMouseButton(0))
     	{
     		buttonWasPressedInTick = true;
	        // Check if the GameObjects are not null
	        if (gameObject1 != null && gameObject2 != null)
	        {

	        	line.SetVertexCount(2);
	            // Update position of the two vertex of the Line Renderer
	            line.SetPosition(0, gameObject1.transform.position);
	            line.SetPosition(1, gameObject2.transform.position);
	            line.sortingOrder = 2;

	            Quaternion q = Quaternion.AngleAxis (speed/(lineDistance(gameObject1, gameObject2)), swingRight * transform.forward);
				rigidbody.MovePosition (q * (rigidbody.transform.position - gameObject2.transform.position) + gameObject2.transform.position);
				rigidbody.MoveRotation (rigidbody.transform.rotation * q);
	        }

     	}

     	//When right mouse button is up 
     	else if (Input.GetMouseButtonUp(0))
     	{
     		//Remove line by removing all vertexs
     		line.SetVertexCount(0);
     		scoreText.text = currentPlanet+"";
     	}
     	

     	//Move Character
     	if (!Input.GetMouseButton(0))
     	{
	     	//Constantly move up
	     	//rigidbody.velocity = new Vector2(0, speed);
	     	float dirFacing = (transform.rotation.z * 100)+90;//*((float)Math.PI/180f));
	     	Debug.Log("dirFacing: " + dirFacing);
	     	Vector2 newDirection = new Vector2((float)Math.Cos((Math.PI / 180) * dirFacing), (float)Math.Sin((Math.PI / 180) * dirFacing));
	     	Debug.Log("newDirection: " + newDirection);
	     	rigidbody.velocity = newDirection * speed;
     	}




     	//Check if mouse button is down and is already past next planet
     	if (!buttonWasPressedInTick && transform.position.y >= (gameLogic.planetCollection[currentPlanet].transform.position.y+0.4f))
     	{
     		currentPlanet++;
     		scoreText.text = currentPlanet+"";
     	}

     }

     //Get length of LineRender
     float lineDistance(GameObject g1, GameObject g2)
     {
     	float xVal = g2.transform.position.x - g1.transform.position.x;
     	float yVal = g2.transform.position.y - g1.transform.position.y;
     	if (xVal < 0)
     	{
     		xVal *= -1;
     	}
     	double totalLength = Math.Sqrt(Math.Pow(xVal, 2) + Math.Pow(yVal, 2));
     	return (float)totalLength;
     }


     //Get Trigger
     private void OnTriggerEnter2D(Collider2D collider)
     {
     	speed = 0;
     	trailPS.Stop();
     	explosionPS.Play();
     	stillAlive = false;
     	playerBody.GetComponent<Renderer>().enabled = false;

     	gameOverScreen.GetComponent<GameOverHandler>().showEndScreen();
     }
}




//Add visual robe decay before letting go at top peak (0 ^)