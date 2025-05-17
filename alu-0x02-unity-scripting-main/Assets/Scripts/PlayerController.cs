using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerBody;
    public float speed = 10.0f;
    private int score = 0;
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           playerBody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
          playerBody.AddForce(Vector3.back * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.AddForce(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerBody.AddForce(Vector3.right * speed);
        }

        // Check if health equals 0 and reload the game

        if (health == 0)
        {
            Debug.Log("Game Over!");

            // Reload the game
            // Scores resets to 0
            // Health resets to 5

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }

    // Score is increased when the player collides with coin
    void OnTriggerEnter(Collider other)
    {
        // check for the tag 'Pickup'
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);

            Destroy(other.gameObject);
        }

        // Traps
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        //Win
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
