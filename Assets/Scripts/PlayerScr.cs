using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
	public Rigidbody rb;         // Include The Rigidbody
	public int Force = -20000;  // How Fast the Player goes
    public int SForce = -100;  // How Fast the Player goes on the x axis
    public int Lives = 3;     // How many Lives the player has
    public GameObject GMObj; // Include the Game Manager
    
    void FixedUpdate()
    {
        rb.AddForce(0, 0, Force * Time.deltaTime);  // Make the player go forward

        if(Input.GetKey("d"))                       // If the D Key is pressed
        {
        	rb.AddForce(SForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);  // Make the player go right
        }

        if(Input.GetKey("a"))                       // If the A Key is pressed
        {
        	rb.AddForce(-SForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Make the player go left
        }

        if(rb.position.y < -5f)                     // If the Player is below 5 on the y axis
        {
            GameManager gmscript = GMObj.GetComponent<GameManager>();   // Get The Game Manager
            gmscript.GameOver();                                       // Tell The Game Manager That The player lost
        }

    }

    void OnCollisionEnter(Collision collInfo) {
        if(collInfo.collider.tag == "Obstacle") {                                             // If player bumps into an Obstacle
            Lives--;                                                                         // Take away one live
            if(Lives < 1) {                                                                 // If The player has less then one live
                Force = 0;                                                                 // Make the player stop
                SForce = 0;                                                               // Make the player stop on x axis
                GameManager gmscript = GMObj.GetComponent<GameManager>();                // Get The Game Manager
                gmscript.GameOver();                                                    // Tell The Game Manager That The player lost
                
            }
        }

        if(collInfo.collider.tag == "SpeedUp") {                                       // If player hits a SpeedUp
            Force = Force-2000;                                                       // Add 2000 Force
        }

        if(collInfo.collider.tag == "0GravityPad") {                                 // If player touches a 0GravityPad
            rb.mass = 0.1f;                                                         // Set player mass to 0.1
            Force = -2000;                                                         // Add 2000 to player speed
        }

        if(collInfo.collider.name == "Cube (7)") {                                // If player Touches EndTrigger (Why The Hell didn't I name the End Trigger)
                GameManager gmscript = GMObj.GetComponent<GameManager>();        // Get The Game Manager
                gmscript.EndGame();                                             // Tell the Game Manager that the player won and the game is over
        }
    }
}