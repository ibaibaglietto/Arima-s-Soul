using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Here we use the command pattern, making commands for the player to execute
public abstract class Command 
{
    public abstract void Execute(Skeleton gameObject);
}

public class JumpCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.Jump();
    }
}

public class StopJumpCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.StopJump();
    }
}

public class MoveLeftCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.MoveLeft();
    }
}
public class StopMoveLeftCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.StopMoveLeft();
    }
}

public class MoveRightCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.MoveRight();
    }
}
public class StopMoveRightCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.StopMoveRight();
    }
}

public class DashCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.Dash();
    }
}

public class StopDashCommand : Command
{
    public override void Execute(Skeleton gameObject)
    {
        gameObject.EndDash();
    }
}
