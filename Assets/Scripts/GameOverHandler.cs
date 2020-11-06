using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
	public GameObject scoreText;
	private Vector3 newScorePosition;
	private Vector3 newScoreScale = new Vector3(2f, 2f, 1f);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        newScorePosition = new Vector3(Screen.width/2, Screen.height*0.65f, -86.1f);
    }

    public void showEndScreen()
    {
    	gameObject.SetActive(true);
    	scoreText.transform.position = newScorePosition;
    	scoreText.transform.localScale = newScoreScale;
    }
 
}
