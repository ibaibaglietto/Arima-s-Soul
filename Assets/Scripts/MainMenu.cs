using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //The cursors
    public Texture2D cursorArrow16;
    public Texture2D cursorArrow20;
    public Texture2D cursorArrow26;
    public Texture2D cursorArrow29;
    public Texture2D cursorArrow32;
    public Texture2D cursorArrow34;
    public Texture2D cursorArrow35;
    public Texture2D cursorArrow36;
    public Texture2D cursorArrow40;
    public Texture2D cursorArrow46;
    public Texture2D cursorArrow48;
    public Texture2D cursorArrow51;
    public Texture2D cursorArrow64;
    public Texture2D cursorArrow96;
    //The main menu
    private GameObject mainMenu;
    //The settings menu
    private GameObject settingsMenu;
    //The controls menu
    private GameObject controlsMenu;
    //The credits menu
    private GameObject creditsMenu;
    //The how to play menu
    private GameObject howToPlayMenu;
    //The pages of the explanation
    [SerializeField] private GameObject[] howToPlayExplanation;
    //The buttons to change the explanation text
    private Button howToPlayPrevButton;
    private Button howToPlayNextButton;
    //The resolution selector dropdown
    private TMP_Dropdown resolution;
    //The toggle of the full screen mode
    private GameObject fullScreenToggle;
    //the screen mode
    private bool fullScreen;
    //The framerate selector dropdown
    private TMP_Dropdown framerate;
    //The previous screen configuration
    private int prevW;
    private int prevH;
    private bool prevFS;
    private int prevFR;
    private float prevMaster;
    private float prevMusic;
    private float prevEffect;
    //The previous language
    private int prevLanguage;
    //The return configuration text
    private TextMeshProUGUI returnText;
    //The time the resolution changes were made
    private float resolutionTime;
    //The confirmation window
    private GameObject confirmationMenu;
    //The language selection menu
    private GameObject languageSelectionMenu;
    //The sound sliders
    private Slider masterSlider;
    private Slider musicSlider;
    private Slider effectsSlider;
    //The texts we need to translate
    private TextMeshProUGUI playText;
    private TextMeshProUGUI settingsText;
    private TextMeshProUGUI creditsText;
    private TextMeshProUGUI exitText;
    private TextMeshProUGUI howToPlayText;
    private TextMeshProUGUI settingsTitle;
    private TextMeshProUGUI resolutionText;
    private TextMeshProUGUI fullScreenText;
    private TextMeshProUGUI frameRateText;
    private TextMeshProUGUI mainVolumeText;
    private TextMeshProUGUI musicText;
    private TextMeshProUGUI effectsText;
    private TextMeshProUGUI languageText;
    private TextMeshProUGUI changeControlsText;
    private TextMeshProUGUI returnSaveText;
    private TextMeshProUGUI returnNoSaveText;
    private TextMeshProUGUI confirmationText;
    private TextMeshProUGUI saveConfirmText;
    private TextMeshProUGUI languageChooseText;
    private TextMeshProUGUI saveLanguageText;
    private TextMeshProUGUI pauseText;
    private TextMeshProUGUI moveLeftText;
    private TextMeshProUGUI moveRightText;
    private TextMeshProUGUI jumpText;
    private TextMeshProUGUI dashText;
    private TextMeshProUGUI controlsTitleText;
    private TextMeshProUGUI returnToSettingsText;
    private TextMeshProUGUI changeControlButtonText;
    private TextMeshProUGUI creditsTitleText;
    private TextMeshProUGUI creditsReturnText;
    private TextMeshProUGUI howToPlayTitleText;
    private TextMeshProUGUI howToPlayReturnText;
    private TextMeshProUGUI howToPlayPage1;
    private TextMeshProUGUI howToPlayPage2;
    private TextMeshProUGUI howToPlayPage3;
    private TextMeshProUGUI howToPlayPage4;
    private TextMeshProUGUI howToPlayPage5;
    private TextMeshProUGUI howToPlayPage6;
    //The music source
    private AudioSource musicSource;
    //The language dropdowns
    private TMP_Dropdown languageDropdown;
    private TMP_Dropdown languageChooseDropdown;
    //An integer to know what page of the explanation menu we have opened
    private int howToPlayNumb = 0;


    void Start()
    {
        //We put the resolution time to 0
        resolutionTime = 0.0f;
        //We find all the UI gameobjects
        mainMenu = GameObject.Find("Main");
        settingsMenu = GameObject.Find("Settings");
        controlsMenu = GameObject.Find("Controls");
        creditsMenu = GameObject.Find("Credits");
        howToPlayMenu = GameObject.Find("HowToPlay");
        resolution = GameObject.Find("DropdownResolution").GetComponent<TMP_Dropdown>();
        framerate = GameObject.Find("DropdownFramerate").GetComponent<TMP_Dropdown>();
        fullScreenToggle = GameObject.Find("Windowed");
        confirmationMenu = GameObject.Find("ConfirmMenu");
        languageSelectionMenu = GameObject.Find("LanguageMenu");
        returnText = GameObject.Find("ReturnText").GetComponent<TextMeshProUGUI>();
        playText = GameObject.Find("PlayButtonText").GetComponent<TextMeshProUGUI>();
        settingsText = GameObject.Find("SettingsButtonText").GetComponent<TextMeshProUGUI>();
        creditsText = GameObject.Find("CreditsButtonText").GetComponent<TextMeshProUGUI>();
        exitText = GameObject.Find("ExitButtonText").GetComponent<TextMeshProUGUI>();
        howToPlayText = GameObject.Find("HowToPlayButtonText").GetComponent<TextMeshProUGUI>();
        settingsTitle = GameObject.Find("SettingsTitleText").GetComponent<TextMeshProUGUI>();
        resolutionText = GameObject.Find("ResolutionText").GetComponent<TextMeshProUGUI>();
        fullScreenText = GameObject.Find("FullScreenText").GetComponent<TextMeshProUGUI>();
        frameRateText = GameObject.Find("FramerateText").GetComponent<TextMeshProUGUI>();
        mainVolumeText = GameObject.Find("MainVolumeText").GetComponent<TextMeshProUGUI>();
        musicText = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        effectsText = GameObject.Find("EffectsText").GetComponent<TextMeshProUGUI>();
        languageText = GameObject.Find("LanguageText").GetComponent<TextMeshProUGUI>();
        languageDropdown = GameObject.Find("DropdownLanguage").GetComponent<TMP_Dropdown>();
        changeControlsText = GameObject.Find("ChangeControlsText").GetComponent<TextMeshProUGUI>();
        returnSaveText = GameObject.Find("ReturnSaveText").GetComponent<TextMeshProUGUI>();
        returnNoSaveText = GameObject.Find("ReturnNoSaveText").GetComponent<TextMeshProUGUI>();
        confirmationText = GameObject.Find("ConfirmationText").GetComponent<TextMeshProUGUI>();
        saveConfirmText = GameObject.Find("SaveConfirmText").GetComponent<TextMeshProUGUI>();
        languageChooseText = GameObject.Find("LanguageChooseText").GetComponent<TextMeshProUGUI>();
        languageChooseDropdown = GameObject.Find("DropdownChooseLanguage").GetComponent<TMP_Dropdown>();
        saveLanguageText = GameObject.Find("SaveLanguageText").GetComponent<TextMeshProUGUI>();
        pauseText = GameObject.Find("PauseText").GetComponent<TextMeshProUGUI>();
        moveLeftText = GameObject.Find("MoveLeftText").GetComponent<TextMeshProUGUI>();
        moveRightText = GameObject.Find("MoveRightText").GetComponent<TextMeshProUGUI>();
        jumpText = GameObject.Find("JumpText").GetComponent<TextMeshProUGUI>();
        dashText = GameObject.Find("DashText").GetComponent<TextMeshProUGUI>();
        controlsTitleText = GameObject.Find("ControlsTitleText").GetComponent<TextMeshProUGUI>();
        returnToSettingsText = GameObject.Find("ReturnControlText").GetComponent<TextMeshProUGUI>();
        changeControlButtonText = GameObject.Find("ChangeControlText").GetComponent<TextMeshProUGUI>();
        creditsTitleText = GameObject.Find("CreditsTitleText").GetComponent<TextMeshProUGUI>();
        creditsReturnText = GameObject.Find("CreditsReturnText").GetComponent<TextMeshProUGUI>();
        howToPlayTitleText = GameObject.Find("HowToPlayTitleText").GetComponent<TextMeshProUGUI>();
        howToPlayReturnText = GameObject.Find("HowToPlayReturnText").GetComponent<TextMeshProUGUI>();
        howToPlayPage1 = GameObject.Find("Page1Text").GetComponent<TextMeshProUGUI>();
        howToPlayPage2 = GameObject.Find("Page2Text").GetComponent<TextMeshProUGUI>();
        howToPlayPage3 = GameObject.Find("Page3Text").GetComponent<TextMeshProUGUI>();
        howToPlayPage4 = GameObject.Find("Page4Text").GetComponent<TextMeshProUGUI>();
        howToPlayPage5 = GameObject.Find("Page5Text").GetComponent<TextMeshProUGUI>();
        howToPlayPage6 = GameObject.Find("Page6Text").GetComponent<TextMeshProUGUI>();
        howToPlayPrevButton = GameObject.Find("HowToPlayPrev").GetComponent<Button>();
        howToPlayNextButton = GameObject.Find("HowToPlayNext").GetComponent<Button>();
        musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
        masterSlider = GameObject.Find("MainVolumeSlider").GetComponent<Slider>();
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
        effectsSlider = GameObject.Find("EffectsSlider").GetComponent<Slider>();
        //We deactivate the parts of the menu that are not shown at the beginning
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(false); 
        creditsMenu.SetActive(false);
        for(int i=1; i<howToPlayExplanation.Length;i++) howToPlayExplanation[i].SetActive(false);
        howToPlayPrevButton.interactable = false;
        howToPlayMenu.SetActive(false);
        confirmationMenu.SetActive(false);
        //We initialize all the playerprefs
        //The resolution width   
        if (!PlayerPrefs.HasKey("resolutionW")) PlayerPrefs.SetInt("resolutionW", 1280);
        //The resolution height
        if (!PlayerPrefs.HasKey("resolutionH")) PlayerPrefs.SetInt("resolutionH", 720);
        //The full screen mode: 0-> windowed, 1-> full screen
        if (!PlayerPrefs.HasKey("fullScreen")) PlayerPrefs.SetInt("fullScreen", 1);
        //The preferred refresh rate
        if (!PlayerPrefs.HasKey("framerate")) PlayerPrefs.SetInt("framerate", 0);
        //An int to save the language
        if (!PlayerPrefs.HasKey("language")) PlayerPrefs.SetInt("language", 0);
        //An int to save if the player has choosen any language
        if (!PlayerPrefs.HasKey("languageChoosen")) PlayerPrefs.SetInt("languageChoosen", 0);
        //A float to set the Master audio mixer
        if (!PlayerPrefs.HasKey("masterAudio")) PlayerPrefs.SetFloat("masterAudio", 1.0f);
        //A float to set the music audio mixer
        if (!PlayerPrefs.HasKey("musicAudio")) PlayerPrefs.SetFloat("musicAudio", 1.0f);
        //A float to set the effects audio mixer
        if (!PlayerPrefs.HasKey("effectsAudio")) PlayerPrefs.SetFloat("effectsAudio", 1.0f);
        //The controls
        if (!PlayerPrefs.HasKey("moveLeft")) PlayerPrefs.SetString("moveLeft", "A");
        if (!PlayerPrefs.HasKey("moveRight")) PlayerPrefs.SetString("moveRight", "D");
        if (!PlayerPrefs.HasKey("jump")) PlayerPrefs.SetString("jump", "Space");
        if (!PlayerPrefs.HasKey("dash")) PlayerPrefs.SetString("dash", "Mouse1");
        if (!PlayerPrefs.HasKey("pause")) PlayerPrefs.SetString("pause", "Escape");
        //We put the real value on the sliders
        masterSlider.value = PlayerPrefs.GetFloat("masterAudio");
        musicSlider.value = PlayerPrefs.GetFloat("musicAudio");
        effectsSlider.value = PlayerPrefs.GetFloat("effectsAudio");
        //We check if the player has choosen the language
        if (PlayerPrefs.GetInt("languageChoosen") == 0)
        {
            languageSelectionMenu.SetActive(true);
            PlayerPrefs.SetInt("languageChoosen", 1);
        }
        else languageSelectionMenu.SetActive(false);
        //We check the settings
        if (PlayerPrefs.GetInt("fullScreen") == 0) fullScreen = false;
        else fullScreen = true;
        Screen.SetResolution(PlayerPrefs.GetInt("resolutionW"), PlayerPrefs.GetInt("resolutionH"), fullScreen, PlayerPrefs.GetInt("framerate"));
        if (PlayerPrefs.GetInt("resolutionW") == 640)
        {
            Cursor.SetCursor(cursorArrow16, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 0;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 800)
        {
            Cursor.SetCursor(cursorArrow20, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 1;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1024)
        {
            Cursor.SetCursor(cursorArrow26, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 576) resolution.value = 2;
            else resolution.value = 3;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1152)
        {
            Cursor.SetCursor(cursorArrow29, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 4;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1280)
        {
            Cursor.SetCursor(cursorArrow32, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 720) resolution.value = 5;
            else if (PlayerPrefs.GetInt("resolutionH") == 800) resolution.value = 6;
            else resolution.value = 7;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1366)
        {
            Cursor.SetCursor(cursorArrow34, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 8;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1400)
        {
            Cursor.SetCursor(cursorArrow35, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 9;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1440)
        {
            Cursor.SetCursor(cursorArrow36, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 10;
            else resolution.value = 11;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1600)
        {
            Cursor.SetCursor(cursorArrow40, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 12;
            else resolution.value = 13;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1856)
        {
            Cursor.SetCursor(cursorArrow46, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 14;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1920)
        {
            Cursor.SetCursor(cursorArrow48, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1080) resolution.value = 15;
            else if (PlayerPrefs.GetInt("resolutionH") == 1200) resolution.value = 16;
            else resolution.value = 17;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2048)
        {
            Cursor.SetCursor(cursorArrow51, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 18;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2560)
        {
            Cursor.SetCursor(cursorArrow64, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1440) resolution.value = 19;
            else resolution.value = 20;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 3840)
        {
            Cursor.SetCursor(cursorArrow96, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 21;
        }
        if (PlayerPrefs.GetInt("framerate") == 30) framerate.value = 0;
        else if (PlayerPrefs.GetInt("framerate") == 60) framerate.value = 1;
        else if (PlayerPrefs.GetInt("framerate") == 90) framerate.value = 2;
        else if (PlayerPrefs.GetInt("framerate") == 120) framerate.value = 3;
        else if (PlayerPrefs.GetInt("framerate") == 144) framerate.value = 4;
        else if (PlayerPrefs.GetInt("framerate") == 0) framerate.value = 5;
        fullScreenToggle.GetComponent<Toggle>().isOn = fullScreen;
        //We write al the texts depending on the choosen language
        WriteTexts();
        //We put the actual value on the language dropdown
        languageDropdown.value = PlayerPrefs.GetInt("language");
        //We play the menu music a bit delayed to wait to the sound settings to apply
        musicSource.PlayDelayed(0.2f);
    }
    //A function to start a new game
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    void FixedUpdate()
    {
        //We check how much time has passed from the moment the player saved the resolution, if the player needs more than 10 seconds to confirm we return to the previous resolution
        if (resolutionTime != 0.0f && (Time.fixedTime - resolutionTime) >= 10)
        {
            resolutionTime = 0.0f;
            ReturnResolution();
        }
        else if (resolutionTime != 0.0f)
        {
            if (PlayerPrefs.GetInt("language") == 0) returnText.text = "Return (" + (10 - (int)(Time.fixedTime - resolutionTime)).ToString() + ")";
            else if (PlayerPrefs.GetInt("language") == 1) returnText.text = "Volver (" + (10 - (int)(Time.fixedTime - resolutionTime)).ToString() + ")";
            else if (PlayerPrefs.GetInt("language") == 2) returnText.text = "Itzuli (" + (10 - (int)(Time.fixedTime - resolutionTime)).ToString() + ")";
        }
    }

    //Function to close the game
    public void CloseGame()
    {
        Debug.Log("Closing game");
        Application.Quit();
    }

    //Function to save the settings
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        prevMaster = PlayerPrefs.GetFloat("masterAudio");
        prevMusic = PlayerPrefs.GetFloat("musicAudio");
        prevEffect = PlayerPrefs.GetFloat("effectsAudio");
        prevLanguage = PlayerPrefs.GetInt("language");
    }

    //Function to close the settings without saving. We return the values to their actual value.
    public void CloseNoSave()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        if (PlayerPrefs.GetInt("resolutionW") == 640)
        {
            Cursor.SetCursor(cursorArrow16, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 0;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 800)
        {
            Cursor.SetCursor(cursorArrow20, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 1;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1024)
        {
            Cursor.SetCursor(cursorArrow26, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 576) resolution.value = 2;
            else resolution.value = 3;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1152)
        {
            Cursor.SetCursor(cursorArrow29, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 4;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1280)
        {
            Cursor.SetCursor(cursorArrow32, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 720) resolution.value = 5;
            else if (PlayerPrefs.GetInt("resolutionH") == 800) resolution.value = 6;
            else resolution.value = 7;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1366)
        {
            Cursor.SetCursor(cursorArrow34, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 8;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1400)
        {
            Cursor.SetCursor(cursorArrow35, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 9;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1440)
        {
            Cursor.SetCursor(cursorArrow36, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 10;
            else resolution.value = 11;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1600)
        {
            Cursor.SetCursor(cursorArrow40, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 12;
            else resolution.value = 13;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1856)
        {
            Cursor.SetCursor(cursorArrow46, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 14;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1920)
        {
            Cursor.SetCursor(cursorArrow48, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1080) resolution.value = 15;
            else if (PlayerPrefs.GetInt("resolutionH") == 1200) resolution.value = 16;
            else resolution.value = 17;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2048)
        {
            Cursor.SetCursor(cursorArrow51, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 18;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2560)
        {
            Cursor.SetCursor(cursorArrow64, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1440) resolution.value = 19;
            else resolution.value = 20;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 3840)
        {
            Cursor.SetCursor(cursorArrow96, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 21;
        }
        if (PlayerPrefs.GetInt("framerate") == 30) framerate.value = 0;
        else if (PlayerPrefs.GetInt("framerate") == 60) framerate.value = 1;
        else if (PlayerPrefs.GetInt("framerate") == 90) framerate.value = 2;
        else if (PlayerPrefs.GetInt("framerate") == 120) framerate.value = 3;
        else if (PlayerPrefs.GetInt("framerate") == 144) framerate.value = 4;
        else if (PlayerPrefs.GetInt("framerate") == 0) framerate.value = 5;
        fullScreenToggle.GetComponent<Toggle>().isOn = fullScreen;
        languageDropdown.value = prevLanguage;
        masterSlider.value = prevMaster;
        musicSlider.value = prevMusic;
        effectsSlider.value = prevEffect;
    }

    //Function to save the changes made on the settings
    public void CloseSave()
    {
        prevW = PlayerPrefs.GetInt("resolutionW");
        prevH = PlayerPrefs.GetInt("resolutionH");
        prevFS = fullScreen;
        prevFR = PlayerPrefs.GetInt("framerate");
        if (resolution.value == 0)
        {
            PlayerPrefs.SetInt("resolutionW", 640);
            PlayerPrefs.SetInt("resolutionH", 480);
        }
        else if (resolution.value == 1)
        {
            PlayerPrefs.SetInt("resolutionW", 800);
            PlayerPrefs.SetInt("resolutionH", 600);
        }
        else if (resolution.value == 2)
        {
            PlayerPrefs.SetInt("resolutionW", 1024);
            PlayerPrefs.SetInt("resolutionH", 576);
        }
        else if (resolution.value == 3)
        {
            PlayerPrefs.SetInt("resolutionW", 1024);
            PlayerPrefs.SetInt("resolutionH", 768);
        }
        else if (resolution.value == 4)
        {
            PlayerPrefs.SetInt("resolutionW", 1152);
            PlayerPrefs.SetInt("resolutionH", 648);
        }
        else if (resolution.value == 5)
        {
            PlayerPrefs.SetInt("resolutionW", 1280);
            PlayerPrefs.SetInt("resolutionH", 720);
        }
        else if (resolution.value == 6)
        {
            PlayerPrefs.SetInt("resolutionW", 1280);
            PlayerPrefs.SetInt("resolutionH", 800);
        }
        else if (resolution.value == 7)
        {
            PlayerPrefs.SetInt("resolutionW", 1280);
            PlayerPrefs.SetInt("resolutionH", 960);
        }
        else if (resolution.value == 8)
        {
            PlayerPrefs.SetInt("resolutionW", 1366);
            PlayerPrefs.SetInt("resolutionH", 768);
        }
        else if (resolution.value == 9)
        {
            PlayerPrefs.SetInt("resolutionW", 1400);
            PlayerPrefs.SetInt("resolutionH", 1050);
        }
        else if (resolution.value == 10)
        {
            PlayerPrefs.SetInt("resolutionW", 1440);
            PlayerPrefs.SetInt("resolutionH", 900);
        }
        else if (resolution.value == 11)
        {
            PlayerPrefs.SetInt("resolutionW", 1440);
            PlayerPrefs.SetInt("resolutionH", 1080);
        }
        else if (resolution.value == 12)
        {
            PlayerPrefs.SetInt("resolutionW", 1600);
            PlayerPrefs.SetInt("resolutionH", 900);
        }
        else if (resolution.value == 13)
        {
            PlayerPrefs.SetInt("resolutionW", 1600);
            PlayerPrefs.SetInt("resolutionH", 1200);
        }
        else if (resolution.value == 14)
        {
            PlayerPrefs.SetInt("resolutionW", 1856);
            PlayerPrefs.SetInt("resolutionH", 1392);
        }
        else if (resolution.value == 15)
        {
            PlayerPrefs.SetInt("resolutionW", 1920);
            PlayerPrefs.SetInt("resolutionH", 1080);
        }
        else if (resolution.value == 16)
        {
            PlayerPrefs.SetInt("resolutionW", 1920);
            PlayerPrefs.SetInt("resolutionH", 1200);
        }
        else if (resolution.value == 17)
        {
            PlayerPrefs.SetInt("resolutionW", 1920);
            PlayerPrefs.SetInt("resolutionH", 1440);
        }
        else if (resolution.value == 18)
        {
            PlayerPrefs.SetInt("resolutionW", 2048);
            PlayerPrefs.SetInt("resolutionH", 1536);
        }
        else if (resolution.value == 19)
        {
            PlayerPrefs.SetInt("resolutionW", 2560);
            PlayerPrefs.SetInt("resolutionH", 1440);
        }
        else if (resolution.value == 20)
        {
            PlayerPrefs.SetInt("resolutionW", 2560);
            PlayerPrefs.SetInt("resolutionH", 1600);
        }
        else if (resolution.value == 21)
        {
            PlayerPrefs.SetInt("resolutionW", 3840);
            PlayerPrefs.SetInt("resolutionH", 2160);
        }
        if (framerate.value == 0) PlayerPrefs.SetInt("framerate", 30);
        else if (framerate.value == 1) PlayerPrefs.SetInt("framerate", 60);
        else if (framerate.value == 2) PlayerPrefs.SetInt("framerate", 90);
        else if (framerate.value == 3) PlayerPrefs.SetInt("framerate", 120);
        else if (framerate.value == 4) PlayerPrefs.SetInt("framerate", 144);
        else if (framerate.value == 5) PlayerPrefs.SetInt("framerate", 0);
        if (fullScreenToggle.GetComponent<Toggle>().isOn) PlayerPrefs.SetInt("fullScreen", 1);
        else PlayerPrefs.SetInt("fullScreen", 0);
        fullScreen = fullScreenToggle.GetComponent<Toggle>().isOn;

        Screen.SetResolution(PlayerPrefs.GetInt("resolutionW"), PlayerPrefs.GetInt("resolutionH"), fullScreenToggle.GetComponent<Toggle>().isOn, PlayerPrefs.GetInt("framerate"));

        if (PlayerPrefs.GetInt("resolutionW") == 640) Cursor.SetCursor(cursorArrow16, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 800) Cursor.SetCursor(cursorArrow20, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1024) Cursor.SetCursor(cursorArrow26, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1152) Cursor.SetCursor(cursorArrow29, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1280) Cursor.SetCursor(cursorArrow32, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1366) Cursor.SetCursor(cursorArrow34, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1400) Cursor.SetCursor(cursorArrow35, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1440) Cursor.SetCursor(cursorArrow36, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1600) Cursor.SetCursor(cursorArrow40, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1856) Cursor.SetCursor(cursorArrow46, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 1920) Cursor.SetCursor(cursorArrow48, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 2048) Cursor.SetCursor(cursorArrow51, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 2560) Cursor.SetCursor(cursorArrow64, Vector2.zero, CursorMode.ForceSoftware);
        else if (PlayerPrefs.GetInt("resolutionW") == 3840) Cursor.SetCursor(cursorArrow96, Vector2.zero, CursorMode.ForceSoftware);

        //If we change the resolution or the full screen mode we ask the player if them can see the window correctly
        if (prevW == PlayerPrefs.GetInt("resolutionW") && prevH == PlayerPrefs.GetInt("resolutionH") && prevFS == fullScreen)
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            resolutionTime = Time.fixedTime;
            confirmationMenu.SetActive(true);
        }
        PlayerPrefs.SetFloat("masterAudio", masterSlider.value);
        PlayerPrefs.SetFloat("musicAudio", musicSlider.value);
        PlayerPrefs.SetFloat("effectsAudio", effectsSlider.value);
    }

    //Function to confirm that the player can see the resolution changes correctly
    public void ConfirmResolution()
    {
        confirmationMenu.SetActive(false);
        settingsMenu.SetActive(false);
        resolutionTime = 0.0f;
        mainMenu.SetActive(true);
    }

    //Function to return to the previous resolution because the player can't see the window correctly
    public void ReturnResolution()
    {
        PlayerPrefs.SetInt("resolutionW", prevW);
        PlayerPrefs.SetInt("resolutionH", prevH);
        if (prevFS) PlayerPrefs.SetInt("fullScreen", 1);
        else PlayerPrefs.SetInt("fullScreen", 0);
        fullScreen = prevFS;
        PlayerPrefs.SetInt("framerate", prevFR);

        Screen.SetResolution(PlayerPrefs.GetInt("resolutionW"), PlayerPrefs.GetInt("resolutionH"), fullScreen, PlayerPrefs.GetInt("framerate"));


        if (PlayerPrefs.GetInt("resolutionW") == 640)
        {
            Cursor.SetCursor(cursorArrow16, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 0;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 800)
        {
            Cursor.SetCursor(cursorArrow20, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 1;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1024)
        {
            Cursor.SetCursor(cursorArrow26, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 576) resolution.value = 2;
            else resolution.value = 3;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1152)
        {
            Cursor.SetCursor(cursorArrow29, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 4;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1280)
        {
            Cursor.SetCursor(cursorArrow32, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 720) resolution.value = 5;
            else if (PlayerPrefs.GetInt("resolutionH") == 800) resolution.value = 6;
            else resolution.value = 7;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1366)
        {
            Cursor.SetCursor(cursorArrow34, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 8;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1400)
        {
            Cursor.SetCursor(cursorArrow35, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 9;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1440)
        {
            Cursor.SetCursor(cursorArrow36, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 10;
            else resolution.value = 11;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1600)
        {
            Cursor.SetCursor(cursorArrow40, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 900) resolution.value = 12;
            else resolution.value = 13;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1856)
        {
            Cursor.SetCursor(cursorArrow46, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 14;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 1920)
        {
            Cursor.SetCursor(cursorArrow48, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1080) resolution.value = 15;
            else if (PlayerPrefs.GetInt("resolutionH") == 1200) resolution.value = 16;
            else resolution.value = 17;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2048)
        {
            Cursor.SetCursor(cursorArrow51, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 18;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 2560)
        {
            Cursor.SetCursor(cursorArrow64, Vector2.zero, CursorMode.ForceSoftware);
            if (PlayerPrefs.GetInt("resolutionH") == 1440) resolution.value = 19;
            else resolution.value = 20;
        }
        else if (PlayerPrefs.GetInt("resolutionW") == 3840)
        {
            Cursor.SetCursor(cursorArrow96, Vector2.zero, CursorMode.ForceSoftware);
            resolution.value = 21;
        }
        if (PlayerPrefs.GetInt("framerate") == 30) framerate.value = 0;
        else if (PlayerPrefs.GetInt("framerate") == 60) framerate.value = 1;
        else if (PlayerPrefs.GetInt("framerate") == 90) framerate.value = 2;
        else if (PlayerPrefs.GetInt("framerate") == 120) framerate.value = 3;
        else if (PlayerPrefs.GetInt("framerate") == 144) framerate.value = 4;
        else if (PlayerPrefs.GetInt("framerate") == 0) framerate.value = 5;
        fullScreenToggle.GetComponent<Toggle>().isOn = fullScreen;

        confirmationMenu.SetActive(false);
    }

    //Function to change the language
    public void ChangeLanguage(bool first)
    {
        if (first) PlayerPrefs.SetInt("language", languageChooseDropdown.value);
        else PlayerPrefs.SetInt("language", languageDropdown.value);
        WriteTexts();
    }

    //Function to write the texts
    public void WriteTexts()
    {
        if (PlayerPrefs.GetInt("language") == 0)
        {
            playText.text = "Play";
            settingsText.text = "Settings";
            creditsText.text = "Credits";
            exitText.text = "Exit";
            howToPlayText.text = "How to play";
            settingsTitle.text = "Settings";
            resolutionText.text = "Resolution";
            fullScreenText.text = "Full Screen";
            frameRateText.text = "Framerate";
            mainVolumeText.text = "Main volume";
            musicText.text = "Music";
            effectsText.text = "Effects";
            languageText.text = "Language";
            changeControlsText.text = "Change controls";
            returnSaveText.text = "Save and return";
            returnNoSaveText.text = "Return without saving";
            confirmationText.text = "Confirm if you can see this window correctly. You will return to the previous configuration if you do not confirm.";
            saveConfirmText.text = "Save changes";
            languageChooseText.text = "Select the language you want the game to be. \nYou can change it whenever you want on the settings.";
            saveLanguageText.text = "Save language";
            creditsTitleText.text = "Credits";
            creditsReturnText.text = "Return";
            howToPlayTitleText.text = "How to play";
            howToPlayPage1.text = "In Arima’s Shadow you will have to catch as many coins as you can, but every time you grab one of them a shadow of yourself from one second before will start following you.";
            howToPlayPage2.text = "If a shadow touches Arima the game will end and you will need to start again from the beginning.";
            howToPlayPage3.text = "To avoid the shadows you can use the jump and the dash in addition to the normal movement.";
            howToPlayPage4.text = "If you exit the screen from any side, you will appear on the other one, really useful to find new ways to avoid the shadows.";
            howToPlayPage5.text = "You can stop the game in any moment, then continuing, restarting or returning to the main menu.";
            howToPlayPage6.text = "You can change all the buttons of the controls at the settings menu, use the button combination that is better to you!";
            howToPlayReturnText.text = "Return";
            pauseText.text = "Pause the game";
            moveLeftText.text = "Move left";
            moveRightText.text = "Move right";
            jumpText.text = "Jump";
            dashText.text = "Dash";
            controlsTitleText.text = "Controls";
            returnToSettingsText.text = "Return to settings";
            changeControlButtonText.text = "Press the button you want to use.";

        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            playText.text = "Jugar";
            settingsText.text = "Ajustes";
            creditsText.text = "Créditos";
            exitText.text = "Salir";
            howToPlayText.text = "Cómo jugar";
            settingsTitle.text = "Ajustes";
            resolutionText.text = "Resolución";
            fullScreenText.text = "Pantalla completa";
            frameRateText.text = "Imágenes por segundo";
            mainVolumeText.text = "Volumen maestro";
            musicText.text = "Música";
            effectsText.text = "Efectos";
            languageText.text = "Idioma";
            changeControlsText.text = "Cambiar los controles";
            returnSaveText.text = "Guardar y volver";
            returnNoSaveText.text = "Volver sin guardar";
            confirmationText.text = "Confirma que puedes ver esta ventana correctamente. Volverás a la configuración previa si no confirmas.";
            saveConfirmText.text = "Guardar los cambios";
            languageChooseText.text = "Selecciona el idioma en el que quieres que esté el juego. \nPuedes cambiarlo cuando quieras en los ajustes.";
            saveLanguageText.text = "Guardar idioma";
            creditsTitleText.text = "Créditos";
            creditsReturnText.text = "Volver";
            howToPlayTitleText.text = "Cómo jugar";
            howToPlayPage1.text = "En Arima’s Shadow tendrás que intentar recoger el máximo número de monedas posible, pero cada vez que cojas una te empezara a perseguir una sombra tuya de hace un segundo.";
            howToPlayPage2.text = "Si una sombra toca a Arima el juego terminará y tendrás que volver a empezar desde el principio.";
            howToPlayPage3.text = "Para evitar las sombras podrás usar los saltos y las embestidas además del movimiento normal.";
            howToPlayPage4.text = "Si sales de la pantalla por cualquiera de los lados, aparecerás en el otro, muy útil para encontrar nuevos caminos para evitar las sombras.";
            howToPlayPage5.text = "Puedes parar el juego en cualquier momento, luego continuándolo, reiniciando o regresando al menú principal.";
            howToPlayPage6.text = "Puedes cambiar los botones de todos los controles desde el menú de ajustes, ¡usa la combinación de botones que más te guste!";
            howToPlayReturnText.text = "Volver";
            pauseText.text = "Pausar el juego";
            moveLeftText.text = "Moverse a la izquierda";
            moveRightText.text = "Moverse a la derecha";
            jumpText.text = "Saltar";
            dashText.text = "Embestir";
            controlsTitleText.text = "Controles";
            returnToSettingsText.text = "Volver a los ajustes";
            changeControlButtonText.text = "Presiona el botón que quieras usar.";
        }
        else if (PlayerPrefs.GetInt("language") == 2)
        {
            playText.text = "Jolastu";
            settingsText.text = "Ezarpenak";
            creditsText.text = "Kredituak";
            exitText.text = "Irten";
            howToPlayText.text = "Nola jolastu";
            settingsTitle.text = "Ezarpenak";
            resolutionText.text = "Erresoluzioa";
            fullScreenText.text = "Pantaila osoa";
            frameRateText.text = "Irudiak segunduko";
            mainVolumeText.text = "Bolumen nagusia";
            musicText.text = "Musika";
            effectsText.text = "Efektuak";
            languageText.text = "Hizkuntzak";
            changeControlsText.text = "Kontrolak aldatu";
            returnSaveText.text = "Gorde eta itzuli";
            returnNoSaveText.text = "Itzuli gorde gabe";
            confirmationText.text = "Lehio hau ondo ikus dezakezula ziurtatu. Ez baduzu baieztatzen lehengo konfiguraziora itzuliko zara.";
            saveConfirmText.text = "Aldaketak gorde";
            languageChooseText.text = "Erabaki zein hizkuntzatan izan nahi duzun jolasa. \nNahi duzunean alda dezakezu ezarpenetan.";
            saveLanguageText.text = "Hizkuntza gorde";
            creditsTitleText.text = "Kredituak";
            creditsReturnText.text = "Itzuli";
            howToPlayTitleText.text = "Nola jolastu";
            howToPlayPage1.text = "Arima's Shadow-en ahal duzun txanpon gehien biltzen saiatu behar zara, baina hauetako bat hartzen duzun bakoitzean duela segundo bateko zure itzal batek jarraituko zaitu. ";
            howToPlayPage2.text = "Itzal batek Arima ukitzen badu jokoa amaitu egingo da eta hasieratik hasi beharko zara berriro.";
            howToPlayPage3.text = "Itzalak saihesteko saltoak eta desplazamendu bizkorrak erabil ditzakezu mugimendu normalaz aparte.";
            howToPlayPage4.text = "Pantailatik irteten bazara edozein aldetik, beste aldean agertuko zara, oso erabilgarria itzalak saihesteko bide berriak aurkitzeko.";
            howToPlayPage5.text = "Jokoa edozein momentuan geldi dezakezu, gero jokoa jarraituz, berrabiaraziz edo menu nagusira itzuliz.";
            howToPlayPage6.text = "Kontrol guztien botoiak ezarpenen menutik alda ditzakezu, zuri gehien gustatzen zaizun botoi konbinazioa erabil ezazu!";
            howToPlayReturnText.text = "Itzuli";
            pauseText.text = "Jokoa gelditu";
            moveLeftText.text = "Ezkerrerantz mugitu";
            moveRightText.text = "Eskuinerantz mugitu";
            jumpText.text = "Salto egin";
            dashText.text = "Desplazamendu bizkorra";
            controlsTitleText.text = "Kontrolak";
            returnToSettingsText.text = "Ezarpenetara itzuli";
            changeControlButtonText.text = "Erabili nahi duzun botoia sakatu.";
        }
    }

    //Function to open the controls menu
    public void OpenControls()
    {
        settingsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    //Function to close the controls menu
    public void CloseControls()
    {
        settingsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    //Function to open the credits menu
    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    //Function to close the credits menu
    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    //Function to open the how to play menu
    public void OpenHowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
    }

    //Function to close the how to play menu
    public void CloseHowToPlay()
    {
        mainMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        howToPlayPrevButton.interactable = false;
        howToPlayNextButton.interactable = true;
        howToPlayExplanation[howToPlayNumb].SetActive(false);
        howToPlayNumb = 0;
        howToPlayExplanation[howToPlayNumb].SetActive(true);
    }

    //Functions to change the how to play text
    public void NextHowToPlay()
    {
        if(howToPlayNumb == 0) howToPlayPrevButton.interactable = true; 
        else if(howToPlayNumb == 4) howToPlayNextButton.interactable = false;
        howToPlayExplanation[howToPlayNumb].SetActive(false);
        howToPlayNumb++;
        howToPlayExplanation[howToPlayNumb].SetActive(true);
    }

    public void PrevHowToPlay()
    {
        if (howToPlayNumb == 1) howToPlayPrevButton.interactable = false;
        else if (howToPlayNumb == 5) howToPlayNextButton.interactable = true;
        howToPlayExplanation[howToPlayNumb].SetActive(false);
        howToPlayNumb--;
        howToPlayExplanation[howToPlayNumb].SetActive(true);
    }

    //Function to close the choose language window
    public void CloseChooseLanguage()
    {
        languageSelectionMenu.SetActive(false);
        if (PlayerPrefs.GetInt("language") == 0) languageDropdown.value = 0;
        else if (PlayerPrefs.GetInt("language") == 1) languageDropdown.value = 1;
        else if (PlayerPrefs.GetInt("language") == 2) languageDropdown.value = 2;
    }
}
