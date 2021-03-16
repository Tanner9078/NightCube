using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAButton : MonoBehaviour
{
	public GameObject WinningUI;    // Include the End Screen UI

    public void OnClick()   // If play again button is clicked
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // Restart current Level
    	WinningUI.SetActive(false);                                   // Disable the End Screen
    }
}
