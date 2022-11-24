using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    //We create a dictionary to bind commands to keys
    Dictionary<string, Command> keys = new Dictionary<string, Command>();
    //The number of commands that we will save
    private static int max = 1250;
    //An array of command arrays that we will use to save all the commands that the player will do
    private Command[,] previousCommands = new Command[max,10];
    //The number of the command array that we are executing now
    private int lastCommands = 0;
    //Two variables to save the commands that will be saved in the previous commands and sent to the skeletons
    private Command[] commands = new Command[10];
    private Command[] sendCommands = new Command[10];
    //The number of commands saved in this command array, can be a maximum of 10
    private int totalCommands = 0;
    //Arrays of vectors to save the position and velocity of the player, to mitigate the error that can be caused when the followers use the commands that the player generated
    private Vector3[] lastPos = new Vector3[100];
    private Vector3[] lastVel = new Vector3[100];
    //The strings where we will save the name of the command that will be generated. For example, if a is the button connected to the moveLeft command, AButtonPress and AButtonRelease will be linked to the MoveLeftCommand and StopMoveLeftCommand.
    private string moveLeftPress;
    private string moveLeftRelease;
    private string moveRightPress;
    private string moveRightRelease;
    private string jumpPress;
    private string jumpRelease;
    private string dashPress;
    private string dashRelease;
    //The keycodes of the 4 movement commands
    private KeyCode moveLeftKey;
    private KeyCode moveRightKey;
    private KeyCode jumpKey;
    private KeyCode dashKey;

    private void Start()
    {
        //We save the strings that will be connected to the commands
        moveLeftPress = PlayerPrefs.GetString("moveLeft") + "ButtonPress";
        moveLeftRelease = PlayerPrefs.GetString("moveLeft") + "ButtonRelease";
        moveRightPress = PlayerPrefs.GetString("moveRight") + "ButtonPress";
        moveRightRelease = PlayerPrefs.GetString("moveRight") + "ButtonRelease";
        jumpPress = PlayerPrefs.GetString("jump") + "ButtonPress";
        jumpRelease = PlayerPrefs.GetString("jump") + "ButtonRelease";
        dashPress = PlayerPrefs.GetString("dash") + "ButtonPress";
        dashRelease = PlayerPrefs.GetString("dash") + "ButtonRelease";
        //We add to the dictionary the strings with their connected command.
        keys.Add(moveLeftPress, new MoveLeftCommand());
        keys.Add(moveLeftRelease, new StopMoveLeftCommand());
        keys.Add(moveRightPress, new MoveRightCommand());
        keys.Add(moveRightRelease, new StopMoveRightCommand());
        keys.Add(jumpPress, new JumpCommand());
        keys.Add(jumpRelease, new StopJumpCommand());
        keys.Add(dashPress, new DashCommand());
        keys.Add(dashRelease, new StopDashCommand());
        //Using refraction, we save the keycodes that will activate the commands
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveLeft"));
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveRight"));
        jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jump"));
        dashKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dash"));
    }
    //We save a maximum of 10 commands that will be sent every 1/50 seconds
    public void HandleInput()
    {
        if (totalCommands < 10)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                commands[totalCommands] = keys[jumpPress];
                totalCommands++;
            }
            if (Input.GetKeyUp(jumpKey))
            {
                commands[totalCommands] = keys[jumpRelease];
                totalCommands++;
            }
            if (Input.GetKeyDown(moveLeftKey))
            {
                commands[totalCommands] = keys[moveLeftPress];
                totalCommands++;
            }
            if (Input.GetKeyUp(moveLeftKey))
            {
                commands[totalCommands] = keys[moveLeftRelease];
                totalCommands++;
            }
            if (Input.GetKeyDown(moveRightKey))
            {
                commands[totalCommands] = keys[moveRightPress];
                totalCommands++;
            }
            if (Input.GetKeyUp(moveRightKey))
            {
                commands[totalCommands] = keys[moveRightRelease];
                totalCommands++;
            }
            if (Input.GetKeyDown(dashKey))
            {
                commands[totalCommands] = keys[dashPress];
                totalCommands++;
            }
            if (Input.GetKeyUp(dashKey))
            {
                commands[totalCommands] = keys[dashRelease];
                totalCommands++;
            }
        }
    }
    //We return the saved commands and save the possition and velocity every 0.5 seconds
    public Command[] ReturnInput(Vector3 pos, Vector3 vel)
    {
        if (lastCommands % 25 == 0)
        {
            lastPos[lastCommands / 25] = pos;
            lastVel[lastCommands / 25] = vel;
        }
        for (int i = 0; i < 10; i++)
        {
            previousCommands[lastCommands, i] = commands[i];
        }
        lastCommands++;
        if (lastCommands >= max)
        {
            lastCommands = 0;
        }
        sendCommands = commands;
        commands = new Command[10];
        totalCommands = 0;
        return sendCommands;
    }
    //A function to get the previously saved position, velocity and commands
    public Command[,] GetPreviousCommands(out Vector3 position, out Vector3 velocity, int numb)
    {
        position = lastPos[numb];
        velocity = lastVel[numb];
        return previousCommands;
    }
}
