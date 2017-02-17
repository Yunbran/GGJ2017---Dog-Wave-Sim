using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int score;        // The player's score.

    private GameObject player;
    private PlayerController playerScript;
    Text text;                      // Reference to the Text component.


    void Start()
    {
        // Set up the reference.
        text = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");

  //      Debug.Log(player);
        playerScript = player.GetComponent<PlayerController>();
   //     Debug.Log(playerScript.score);

        // Reset the score.
        score = 0;
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + playerScript.score;

    }
}