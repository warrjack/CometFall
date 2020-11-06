using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

	public List<GameObject> planets = new List<GameObject>();				//List of all planet game objects
	public List<GameObject> planetCollection = new List<GameObject>();		//List of planet objects only in scene
	public GameObject player;												//Player game object
	private int randomNumber = 0;
	private float randomFloat = 0f;

	private float planetPlacementX;
	private float planetPlacementY;
	private float previousPlanetY = 0f;

    // Start is called before the first frame update
    void Start()
    {
    	//Create 10 new planets
        createNewPlanet(10);
    }

    Vector3 planetPlacement(int planetNumber)
    {
    	//X
    	planetPlacementX = Random.Range(-2f, 2f);

    	//Y
    	planetPlacementY = Random.Range(3.045f, 4.045f);
    	Vector3 position = new Vector3(planetPlacementX, planetPlacementY + previousPlanetY, -1f);
    	previousPlanetY = position.y;


    	return position;
    }

    public void createNewPlanet(int loop)
    {
    	for(int i = 0; i < loop; i++)
    	{
    		randomNumber = Random.Range(0, planets.Count - 1);
			GameObject newPlanet = (GameObject) Instantiate(planets[randomNumber], planetPlacement(planetCollection.Count - 1), Quaternion.identity);
			randomFloat = Random.Range(0.7f, 1.3f);
			newPlanet.transform.localScale = new Vector3(randomFloat, randomFloat, randomFloat);
       		planetCollection.Add(newPlanet);
    	}   	
    }
}
