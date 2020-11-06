using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeHandler : MonoBehaviour
{

	public void fadeToNewScene(Image fadeImage, bool isFading, string nameOfScene, float speedOfFade)
	{
	    StartCoroutine(FadeImage(fadeImage, isFading, nameOfScene, speedOfFade));
	}


    IEnumerator FadeImage(Image img, bool fadeAway, string sceneName, float speed)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= (Time.deltaTime*2))
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
    		img.enabled = false;
        }

        // fade from transparent to opaque
        else
        {
    		img.enabled = true;
            // loop over 1 second
            for (float i = 0; i <= 1; i += (Time.deltaTime*speed))
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            if(sceneName != "")
            {
        		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        	}
        }
    }
}
