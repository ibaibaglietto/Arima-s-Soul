using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We will use the component pattern to create a skeleton that both the player and the follower can use
public class Skeleton : MonoBehaviour
{
    [SerializeField] private float delay;
    private InputComponent input;
    private PhysicsComponent physics;
    private GraphicsComponent graphics;
    public InputHandler inputHandler;
    //The prefab of the dash and the gameobject where we are going to save it
    [SerializeField] private GameObject dashPrefab;
    private GameObject shadow;
    //The public variables that the components will need
    public bool isPlayer;
    public bool jump = false;
    public float speed = 0.0f;
    public bool falling = false;
    public bool onAir = false;
    public bool check = true;
    public bool dash = false;
    public bool dashing = false;
    public int lookingRight = 1;
    public bool dashShadow = false;
    public bool dead = false;
    public bool activating = false;
    public float activateTime;
    public bool gravity = false;
    public bool waiting;
    public AudioClip jumpClip;
    public AudioClip dashClip;
    public AudioClip deathClip;
    //An int to create the shadows that will follow the player
    private static readonly int start = 1250;
    //We will initialize the components looking if it is the player and the delay we need to apply
    void Start()
    {
        if (isPlayer)
        {
            input = new PlayerInputComponent();
            physics = new NormalPhysicsComponent();
            graphics = new ArimaGraphicsComponent();
        }
        else
        {
            input = new FollowInputComponent();
            input.Create((int)(start - delay*50));
            physics = new NormalPhysicsComponent();
            graphics = new ArimaGraphicsComponent();
        }
    }

    // In update and fixed update we update the components of our skeleton: input, graphics and physics
    void Update()
    {
        input.Update(this);
        graphics.Update(this);
    }
    private void FixedUpdate()
    {
        input.FixedUpdate(this);
        physics.FixedUpdate(this);
    }

    //A function to manage the waiting state of the skeleton, for example for the initial countdown
    public void SetWait(bool w)
    {
        waiting = w;
        if (!w && isPlayer) input.CheckInputs(this);
    }

    //Functions to change the variables of the movement of the skeleton
    public void Jump()
    {
        jump = true;
    }

    public void StopJump()
    {
        jump = false;
        gravity = true;
    }

    public void MoveRight()
    {
        speed += 1.0f;
    }
    public void StopMoveRight()
    {
        speed -= 1.0f;
    }

    public void MoveLeft()
    {
        speed -= 1.0f;
    }
    public void StopMoveLeft()
    {
        speed += 1.0f;
    }

    public void Dash()
    {
        dash = true;
    }
    public void EndDash()
    {
        dash = false;
    }

    public void StopDashing()
    {
        dashing = false;
    }

    //Function to kill the skeleton
    public void Die()
    {
        dead = true;
    }

    //Function to activate a new follower, saving the time it was activated
    public void ActivateFollower()
    {
        if (!isPlayer)
        {
            activateTime = Time.fixedTime;
            activating = true;
        }
    }

    //Function to deactivate the follower. We change the alpha to make it invisible but we don't destroy it.
    public void DectivateFollower()
    {
        if (!isPlayer)
        {
            activating = false;
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.0f);
            transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //A function to create shadows when a skeleton dashes
    public void CreateDashShadow()
    {
        shadow = Instantiate(dashPrefab, transform.position, transform.rotation);
        if (lookingRight != 1)
        {
            Vector3 theScale = shadow.transform.localScale;
            theScale.x *= -1;
            shadow.transform.localScale = theScale;
        }
        else
        {
            Vector3 theScale = shadow.transform.localScale;
            theScale.x *= 1;
            shadow.transform.localScale = theScale;
        }
    }
}
