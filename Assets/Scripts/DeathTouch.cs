using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : MonoBehaviour
{
    //The gamecontroller
    private GameController gameController;
    //We find the gamecontroller
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    //When the player is touched it dies and we end the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Skeleton>().Die();
            gameController.EndGame();
        }
    }

}
