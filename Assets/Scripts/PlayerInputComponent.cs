using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : InputComponent
{
    //An array to save the commands
    private Command[] commands = new Command[10];
    //An int to know what is the command that we are executing
    private int commandNumb = 0;

    //We check the inputs every frame
    public override void Update(Skeleton gameObject)
    {
        if(!gameObject.waiting) gameObject.inputHandler.HandleInput();
    }
    //Trying to make it more consistent, we execute the commands 50 times every second. If we did this in update, the follower movement can be inconsistent.
    public override void FixedUpdate(Skeleton gameObject)
    {
        commands = gameObject.inputHandler.ReturnInput(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Rigidbody2D>().velocity);
        while (commands[commandNumb] != null)
        {
            commands[commandNumb].Execute(gameObject);
            commandNumb++;
        }
        commandNumb = 0;
    }

    //We don't need to use create with the player, because we don't need any delay on their movement
    public override void Create(int numb)
    {
        
    }

    public override void CheckInputs(Skeleton gameObject)
    {
        gameObject.inputHandler.CheckInput();
    }
}
