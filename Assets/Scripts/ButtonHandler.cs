using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // the image you want to fade, assign in inspector
    public Image fadeImg;
    public bool PlayButton;
    public bool SettingsButton;
    public bool RestartButton;
    public bool MenuButton;
    public FadeHandler fadeHandler;

    void Start()
    {
    	Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnButtonClick);
    }
   
    public void OnButtonClick()
    {

    	if(PlayButton)
    	{
	        // fades the image out when you click
	        fadeHandler.fadeToNewScene(fadeImg, false, "GamePlay", 1f);

    	}

    	else if (SettingsButton)
    	{
    		//Show Customizer and reset button
    	}

    	else if(RestartButton)
    	{
	        // fades the image out when you click
	        fadeHandler.fadeToNewScene(fadeImg, false, "GamePlay", 1f);
    	}

    	else if (MenuButton)
    	{
    		//Show Customizer and reset button
	        fadeHandler.fadeToNewScene(fadeImg, false, "Main Menu", 1f);
    	}
    }    
}
