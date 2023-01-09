using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We will use the state pattern to create a state machine for the graphics component
public class ArimaGraphicsComponent : GraphicsComponent
{
    //The states of the state machine that we will follow
    enum State
    {
        STATE_IDLE_RIGHT,
        STATE_IDLE_LEFT,
        STATE_RUNNING_RIGHT,
        STATE_RUNNING_LEFT,
        STATE_JUMPING_RIGHT,
        STATE_JUMPING_LEFT,
        STATE_FALLING_RIGHT,
        STATE_FALLING_LEFT,
        STATE_DASHING_RIGHT,
        STATE_DASHING_LEFT,
        STATE_DEAD
    };
    //The starting state
    private State state = State.STATE_IDLE_RIGHT;

    //We built a state machine to send the correct variables to the animator and to play the correct sounds when the state changes.
    public override void Update(Skeleton gameObject)
    {
        switch (state)
        {
            case State.STATE_IDLE_RIGHT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing && !gameObject.waiting)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_RIGHT;

                }
                else if (gameObject.jump && !gameObject.waiting)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.jumpClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isJumping", true);
                    state = State.STATE_JUMPING_RIGHT;
                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_RIGHT;
                }
                else if (gameObject.speed < -0.1f && !gameObject.waiting)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", false);
                    gameObject.lookingRight = -1;
                    state = State.STATE_RUNNING_LEFT;
                }
                else if (gameObject.speed > 0.1f && !gameObject.waiting)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                    state = State.STATE_RUNNING_RIGHT;
                }
                break;
            case State.STATE_IDLE_LEFT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_LEFT;
                }
                else if (gameObject.jump)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.jumpClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isJumping", true);
                    state = State.STATE_JUMPING_LEFT;
                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_LEFT;
                }
                else if (gameObject.speed < -0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                    state = State.STATE_RUNNING_LEFT;
                }
                else if (gameObject.speed > 0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", true);
                    gameObject.lookingRight = 1;
                    state = State.STATE_RUNNING_RIGHT;
                }
                break;
            case State.STATE_RUNNING_RIGHT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_RIGHT;

                }
                else if (gameObject.jump)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.jumpClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isJumping", true);
                    state = State.STATE_JUMPING_RIGHT;
                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_RIGHT;
                }
                else if (gameObject.speed < -0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", false);
                    gameObject.lookingRight = -1;
                    state = State.STATE_RUNNING_LEFT;
                }
                else if(gameObject.speed == 0.0f)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    state = State.STATE_IDLE_RIGHT;
                }
                break;
            case State.STATE_RUNNING_LEFT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if(gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_LEFT;

                }
                else if (gameObject.jump)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.jumpClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isJumping", true);
                    state = State.STATE_JUMPING_LEFT;
                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_LEFT;
                }
                else if (gameObject.speed > 0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", true);
                    gameObject.lookingRight = 1;
                    state = State.STATE_RUNNING_RIGHT;
                }
                else if (gameObject.speed == 0.0f)
                {
                    gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    state = State.STATE_IDLE_LEFT;
                }
                break;
            case State.STATE_JUMPING_RIGHT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_RIGHT;

                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_RIGHT;
                }
                else if (!gameObject.onAir)
                {
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_IDLE_RIGHT;
                }
                else if (gameObject.speed < -0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", false);
                    gameObject.lookingRight = -1;
                    state = State.STATE_JUMPING_LEFT;
                }
                break;
            case State.STATE_JUMPING_LEFT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_LEFT;
                }
                else if (gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", true);
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_FALLING_LEFT;
                }
                else if (!gameObject.onAir)
                {
                    gameObject.GetComponent<Animator>().SetBool("isJumping", false);
                    state = State.STATE_IDLE_LEFT;
                }
                else if (gameObject.speed > 0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", true);
                    gameObject.lookingRight = 1;
                    state = State.STATE_JUMPING_RIGHT;
                }
                break;
            case State.STATE_FALLING_RIGHT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_RIGHT;
                }
                else if (!gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", false);
                    gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    state = State.STATE_IDLE_RIGHT;
                }
                else if (gameObject.speed < -0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", false);
                    gameObject.lookingRight = -1;
                    state = State.STATE_FALLING_LEFT;
                }
                break;
            case State.STATE_FALLING_LEFT:
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (gameObject.dashing)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.dashClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", true);
                    state = State.STATE_DASHING_LEFT;
                }
                else if (!gameObject.falling)
                {
                    gameObject.GetComponent<Animator>().SetBool("isFalling", false);
                    gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    state = State.STATE_IDLE_LEFT;
                }
                else if (gameObject.speed > 0.1f)
                {
                    gameObject.GetComponent<Animator>().SetBool("lookingRight", true);
                    gameObject.lookingRight = 1;
                    state = State.STATE_FALLING_RIGHT;
                }
                break;
            case State.STATE_DASHING_RIGHT:
                if (gameObject.GetComponent<SpriteRenderer>().color.a > 0.1f && !gameObject.waiting) gameObject.CreateDashShadow();
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (!gameObject.dashing)
                {
                    if (!gameObject.falling)
                    {
                        gameObject.GetComponent<Animator>().SetBool("isFalling", false);
                        gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", false);
                    state = State.STATE_IDLE_RIGHT;
                }
                break;
            case State.STATE_DASHING_LEFT:
                if(gameObject.GetComponent<SpriteRenderer>().color.a > 0.1f && !gameObject.waiting) gameObject.CreateDashShadow();
                if (gameObject.dead)
                {
                    if (gameObject.isPlayer)
                    {
                        gameObject.GetComponent<AudioSource>().clip = gameObject.deathClip;
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    state = State.STATE_DEAD;
                }
                else if (!gameObject.dashing)
                {
                    if (!gameObject.falling)
                    {
                        gameObject.GetComponent<Animator>().SetBool("isFalling", false);
                        gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                    }
                    gameObject.GetComponent<Animator>().SetBool("isDashing", false);
                    state = State.STATE_IDLE_LEFT;
                }
                break;
        }
        //When the follower is being activated we change the alpha according to the time and when it is fully visible we enable the hitbox that can kill the player.
        if (gameObject.activating)
        {
            if(Time.fixedTime - gameObject.activateTime < 1.0f) gameObject.GetComponent<SpriteRenderer>().color = new Color(0.05f, 0.2f, 0.1f, Time.fixedTime - gameObject.activateTime);
            else
            {
                gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 1.0f, 0.6f, 1.0f);
                gameObject.activating = false;
            }
        }
    }

}
