using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	bool IsGameOver = false;        // Game isn't over
	public GameObject WinningUI;   // WinningUI is the UI that players see when they win the Game

	public void GameOver() 
	{
		if(IsGameOver == false) {           // If Game Isn't over
			IsGameOver = true;             // Game Is now Over
			Debug.Log("Game Over");
			Restart();
		}
	}

    public void EndGame()
    {
    	WinningUI.SetActive(true);      // Enable End Screen
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    // Restart level
    }
}