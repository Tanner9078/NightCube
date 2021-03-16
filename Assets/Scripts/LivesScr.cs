using UnityEngine;
using UnityEngine.UI;

public class LivesScr : MonoBehaviour
{
	public GameObject playerObj;     // This is the player
	public Text LivesText;          // This is Text that shows how many lives the play has

    // Update is called once per frame
    void Update()
    {
        PlayerScr pscript = playerObj.GetComponent<PlayerScr>();    // Get player
        int Lives = pscript.Lives;                                 // Get How many lives the player has
        LivesText.text = "Lives: " + Lives.ToString();            // Print number of lives to screen
    }
}