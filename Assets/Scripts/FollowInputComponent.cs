using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInputComponent : InputComponent
{
    //The number of command arrays that we will save
    private static readonly int max = 1250;
    //An array of command arrays that we will use to save all the commands that the player will do
    private Command[,] previousCommands = new Command[max, 10];
    //The number of the command array that we are executing now
    private int lastCommand;
    //The number of the command that we are executing
    private int commandNumb = 0;
    //The temporary position and velocity that we will put to the follower if the command number is divisible by 25 (every 0.5 seconds).
    private Vector3 tempPos;
    private Vector3 tempVel;

    //We create the component with a delay, to know the command that we need to execute
    public override void Create(int numb)
    {
        lastCommand = numb;
    }

    public override void Update(Skeleton gameObject)
    {
        
    }
    //We do the same as we did with the player, but this time we check the position and the velocity every 0.5 seconds to counter all the small errors that can happen when the followers are moving.
    public override void FixedUpdate(Skeleton gameObject)
    {
        previousCommands = gameObject.inputHandler.GetPreviousCommands(out tempPos, out tempVel, lastCommand / 25);
        if (lastCommand%25==0)
        {
            gameObject.GetComponent<Transform>().position = tempPos;
            gameObject.GetComponent<Rigidbody2D>().velocity = tempVel;
        }
        while (previousCommands[lastCommand, commandNumb] != null && commandNumb < 10)
        {
            previousCommands[lastCommand, commandNumb].Execute(gameObject);
            commandNumb++;
        }
        lastCommand++;
        if (lastCommand >= max) lastCommand = 0; 
        commandNumb = 0;
    }
    //We will only use this with the player
    public override void CheckInputs(Skeleton gameObject)
    {
        
    }

}
