using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLogic : MonoBehaviour
{

	public List<GameObject> backgroundImageObjects = new List<GameObject>();	//List of all background image objects						
	public GameObject player;													//Player gameobject
	private Vector3 startingPoint;												//Starting reference point for background movement
	public float playerDisplacement;									//Displacement of player from starting reference before background moves and reference is reset
	private int lastBIOElement = 0;												//Get last backgroundImageObjects position to clean code
	public bool inGame = false;												
	
	public GameObject gl;
	private GameLogic gameLogic;
	public Image fadeImg;
    public FadeHandler fadeHandler;

    private float fadeInSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
    	//Get GameLogic script component
    	if (inGame)
    	{
     		gameLogic = gl.GetComponent<GameLogic>();
    	}

	    fadeHandler.fadeToNewScene(fadeImg, true, "", 1f);

    	//Get starting point of player
    	startingPoint = player.transform.position;
    	//Set variable of last backgroundImageObjects position to variable to clean code
        lastBIOElement = backgroundImageObjects.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
    	//Player is far enough to move background

        if (player.transform.position.y >= startingPoint.y + playerDisplacement)
        {
        	backgroundLoop(player, backgroundImageObjects, lastBIOElement, playerDisplacement);
        	if (inGame)
    		{	
    			gameLogic.createNewPlanet(3);
    		}
        	
        }
    }

    public void backgroundLoop(GameObject centerRef, List<GameObject> backgroundImgObjs, int lastBackgroundImageElement, float playerDisp)
    {
    	//Reset starting reference point
    	startingPoint = centerRef.transform.position;

    	//Move bottom (last) image to top (first)
    	backgroundImgObjs[lastBackgroundImageElement].transform.position = new Vector3(transform.position.x, backgroundImgObjs[lastBackgroundImageElement].transform.position.y + (playerDisp*(backgroundImgObjs.Count)), transform.position.z);
    	//Move the last element to the front by inserting a clone into position 0
    	backgroundImgObjs.Insert(0, backgroundImgObjs[lastBackgroundImageElement]);
    	//Remove the old element reference at the end of the list (+1 to reach the last veriable, because there is an extra clone element)
    	backgroundImgObjs.RemoveAt(lastBackgroundImageElement+1);
    }
}
