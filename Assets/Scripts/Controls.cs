using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    //The action we are changing: 0 -> move left, 1 -> move right, 2 -> Jump, 3 -> Dash, 4 -> Pause
    private int action;
    //A boolean to know if we are waiting for a new button
    private bool waitingKey;
    //The text that will appear when we are changing a button and the gameobject of the warning
    [SerializeField] private TextMeshProUGUI changeButtonText;
    [SerializeField] private GameObject changeButton;
    //The buttons for the 5 controls that we can change
    [SerializeField] private GameObject moveLeftImage;
    [SerializeField] private GameObject moveRightImage;
    [SerializeField] private GameObject jumpImage;
    [SerializeField] private GameObject dashImage;
    [SerializeField] private GameObject pauseImage;
    //All the sprites of the keys that can be used 
    public Sprite Escape;
    public Sprite F1;
    public Sprite F2;
    public Sprite F3;
    public Sprite F4;
    public Sprite F5;
    public Sprite F6;
    public Sprite F7;
    public Sprite F8;
    public Sprite F9;
    public Sprite F10;
    public Sprite F11;
    public Sprite F12;
    public Sprite Alpha1;
    public Sprite Alpha2;
    public Sprite Alpha3;
    public Sprite Alpha4;
    public Sprite Alpha5;
    public Sprite Alpha6;
    public Sprite Alpha7;
    public Sprite Alpha8;
    public Sprite Alpha9;
    public Sprite Alpha0;
    public Sprite Backspace;
    public Sprite Return;
    public Sprite RightShift;
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;
    public Sprite E;
    public Sprite F;
    public Sprite G;
    public Sprite H;
    public Sprite I;
    public Sprite J;
    public Sprite K;
    public Sprite L;
    public Sprite M;
    public Sprite N;
    public Sprite O;
    public Sprite P;
    public Sprite Q;
    public Sprite R;
    public Sprite S;
    public Sprite T;
    public Sprite U;
    public Sprite V;
    public Sprite W;
    public Sprite X;
    public Sprite Y;
    public Sprite Z;
    public Sprite Comma;
    public Sprite Period;
    public Sprite Minus;
    public Sprite Insert;
    public Sprite Home;
    public Sprite Delete;
    public Sprite End;
    public Sprite PageUp;
    public Sprite PageDown;
    public Sprite Tab;
    public Sprite CapsLock;
    public Sprite LeftShift;
    public Sprite LeftControl;
    public Sprite LeftAlt;
    public Sprite Space;
    public Sprite RightControl;
    public Sprite LeftArrow;
    public Sprite RightArrow;
    public Sprite UpArrow;
    public Sprite DownArrow;
    public Sprite KeypadDivide;
    public Sprite KeypadMultiply;
    public Sprite KeypadMinus;
    public Sprite KeypadPlus;
    public Sprite KeypadEnter;
    public Sprite KeypadPeriod;
    public Sprite Keypad1;
    public Sprite Keypad2;
    public Sprite Keypad3;
    public Sprite Keypad4;
    public Sprite Keypad5;
    public Sprite Keypad6;
    public Sprite Keypad7;
    public Sprite Keypad8;
    public Sprite Keypad9;
    public Sprite Keypad0;
    public Sprite Mouse0;
    public Sprite Mouse1;
    public Sprite Mouse2;


    void Start()
    {
        //We initialize variables
        waitingKey = false;
        //We deactivate the change button gameobject
        changeButton.SetActive(false);
        //Looking at the player prefs we know the name of the key, so using reflection we can take the sprite of the same name
        pauseImage.GetComponent<Image>().sprite = (Sprite)GetType().GetField(PlayerPrefs.GetString("pause")).GetValue(this);
        moveLeftImage.GetComponent<Image>().sprite = (Sprite)GetType().GetField(PlayerPrefs.GetString("moveLeft")).GetValue(this);
        moveRightImage.GetComponent<Image>().sprite = (Sprite)GetType().GetField(PlayerPrefs.GetString("moveRight")).GetValue(this);
        jumpImage.GetComponent<Image>().sprite = (Sprite)GetType().GetField(PlayerPrefs.GetString("jump")).GetValue(this);
        dashImage.GetComponent<Image>().sprite = (Sprite)GetType().GetField(PlayerPrefs.GetString("dash")).GetValue(this);
        //We change the text depending on the selected language
        if (PlayerPrefs.GetInt("language") == 0) changeButtonText.text = "Press the button you want to use.";
        else if(PlayerPrefs.GetInt("language") == 1) changeButtonText.text = "Presiona el botón que quieres usar.";
        else if (PlayerPrefs.GetInt("language") == 2) changeButtonText.text = "Sakatu erabili nahi duzun botoia.";
    }


    void Update()
    {
        if (waitingKey)
        {
            //We check for every possible key of the type keycode, but we only do it when we are looking for a new key
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    if(GetType().GetField(kcode.ToString()) != null)
                    {
                        //When we know that we pressed a key we look that it isn't already used, and if so we asign the key to the command
                        if (PlayerPrefs.GetString("moveLeft") != kcode.ToString() && PlayerPrefs.GetString("moveRight") != kcode.ToString() && PlayerPrefs.GetString("jump") != kcode.ToString() && PlayerPrefs.GetString("dash") != kcode.ToString() && PlayerPrefs.GetString("pause") != kcode.ToString())
                        {
                            var button = (Sprite)GetType().GetField(kcode.ToString()).GetValue(this);
                            if (action == 0)
                            {
                                moveLeftImage.GetComponent<Image>().sprite = button;
                                PlayerPrefs.SetString("moveLeft", kcode.ToString());
                            }
                            else if (action == 1)
                            {
                                moveRightImage.GetComponent<Image>().sprite = button;
                                PlayerPrefs.SetString("moveRight", kcode.ToString());
                            }
                            else if (action == 2)
                            {
                                jumpImage.GetComponent<Image>().sprite = button;
                                PlayerPrefs.SetString("jump", kcode.ToString());
                            }
                            else if (action == 3)
                            {
                                dashImage.GetComponent<Image>().sprite = button;
                                PlayerPrefs.SetString("dash", kcode.ToString());
                            }
                            else if (action == 4)
                            {
                                pauseImage.GetComponent<Image>().sprite = button;
                                PlayerPrefs.SetString("pause", kcode.ToString());
                            }
                            waitingKey = false;
                            changeButton.SetActive(false);
                        }
                        //If we are using the key or it isn't supported we print a new text for the player to know that they need to press anothe button
                        else
                        {
                            if (PlayerPrefs.GetInt("language") == 0) changeButtonText.text = "You are already using that button, press another one.";
                            else if (PlayerPrefs.GetInt("language") == 1) changeButtonText.text = "Ya estas usando ese botón, presiona otro.";
                            else if (PlayerPrefs.GetInt("language") == 2) changeButtonText.text = "Botoia jadanik erabilita dago, beste bat sakatu.";
                        }
                    }
                    else if(kcode.ToString() != "LeftApple")
                    {
                        if (PlayerPrefs.GetInt("language") == 0) changeButtonText.text = "This button is not supported, press another one.";
                        else if (PlayerPrefs.GetInt("language") == 1) changeButtonText.text = "Este botón no esta soportado, presiona otro.";
                        else if (PlayerPrefs.GetInt("language") == 2) changeButtonText.text = "Botoi hau ezin da erabili, beste bat sakatu.";
                    }
                }
            }
        }
    }

    //A function that will start the change button action
    public void ChangeButton(int a)
    {
        action = a;
        waitingKey = true;
        changeButton.SetActive(true);
        //We change the text depending on the selected language
        if (PlayerPrefs.GetInt("language") == 0) changeButtonText.text = "Press the button you want to use.";
        else if (PlayerPrefs.GetInt("language") == 1) changeButtonText.text = "Presiona el botón que quieres usar.";
        else if (PlayerPrefs.GetInt("language") == 2) changeButtonText.text = "Sakatu erabili nahi duzun botoia.";
    }
}
