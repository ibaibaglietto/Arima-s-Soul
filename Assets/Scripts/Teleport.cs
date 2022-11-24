using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //An int to know if the teleport is the one at the right
    [SerializeField] private int isRight;
    //When a player o a follower collide with the tp they are teleported to the other side
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Follower") collision.transform.position = new Vector3(-20f * isRight, collision.transform.position.y, collision.transform.position.z); 
    }
}
