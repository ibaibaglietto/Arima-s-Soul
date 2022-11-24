using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //The game controller
    private GameController gameController;
    //A boolean to know if the coin is picked
    private bool isPicked = false;
    //The audio source that will play the coin sound
    private AudioSource coinSource;
    private void Start()
    {
        //We find the game controller and the coin source
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        coinSource = GameObject.Find("CoinSource").GetComponent<AudioSource>();
    }

    //If the coin spawns on a obstacle we create a new one and destroy this
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            gameController.NewCoin();
            Destroy(gameObject);
        }
    }

    //When the player collides with a coin we send the position of the last coin to the game controller, play the sound and the animation and create a new follower and a coin.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CoinGraber" && !isPicked && !gameController.GetGameEnded())
        {
            coinSource.Play();
            isPicked = true;
            GetComponent<Animator>().SetTrigger("Pick");
            gameController.SetLastPos(gameObject.transform.position);
            gameController.NewFollower();
            gameController.NewCoin();
        }
    }

    //Function to self destroy the coin when the pick animation ends.
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
