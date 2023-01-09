using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //The camera
    [SerializeField] private Camera mainCamera;
    //The shadows that will follow the player
    [SerializeField] private Skeleton[] followers;
    //The prefab of the coin
    [SerializeField] private GameObject coinPrefab;
    //The gameobject where the score will be written
    [SerializeField] private GameObject score;
    //The gameobject where the countdown text will appear
    [SerializeField] private GameObject countDown;
    //The player
    [SerializeField] private Skeleton player;
    //The pause menu, the resume button and the text that we will change depending on the language
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreNumb;
    [SerializeField] private TextMeshProUGUI resumeText;
    [SerializeField] private TextMeshProUGUI restartText;
    [SerializeField] private TextMeshProUGUI returnText;
    //The actual active followers
    private int activeFollowers = 0;
    //The position of the last coin. The first one is the starting position
    private Vector3 lastPos = new Vector3(0.0f, -9.55f, 0.0f);
    //The starting time
    private float startTime;
    //A boolean to know if the game is starting
    private bool starting;
    //The keycode of the button that will pause the game
    private KeyCode pauseKey;
    //Booleans to know if the game is paused and if the game ended
    private bool paused;
    private bool gameEnded;

    public void Start()
    {
        //We make the cursor invisible, because we don't need it when we are playing. We also lock it on the window.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        //We change the camera size depending on the resolution
        if (Mathf.Abs((float)PlayerPrefs.GetInt("resolutionW") / PlayerPrefs.GetInt("resolutionH") - 16.0f / 9.0f) < 0.0001f ) mainCamera.orthographicSize = 11.34812f;
        else if (Mathf.Abs((float)PlayerPrefs.GetInt("resolutionW") / PlayerPrefs.GetInt("resolutionH") - 16.0f / 10.0f) < 0.0001f) mainCamera.orthographicSize = 12.63513f;
        else if (Mathf.Abs((float)PlayerPrefs.GetInt("resolutionW") / PlayerPrefs.GetInt("resolutionH") - 4.0f / 3.0f) < 0.0001f) mainCamera.orthographicSize = 15.1287f;
        //We save the starting time and initialize the variables
        startTime = Time.fixedTime;
        starting = true;
        paused = false;
        gameEnded = false;
        //We change the text depending on the language
        if (PlayerPrefs.GetInt("language") == 0)
        {
            pauseText.text = "GAME PAUSED";
            resumeText.text = "Resume";
            restartText.text = "Restart";
            returnText.text = "Return to main menu";
        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            pauseText.text = "JUEGO PAUSADO";
            resumeText.text = "Continuar";
            restartText.text = "Reiniciar";
            returnText.text = "Volver al menú principal";
        }
        else if (PlayerPrefs.GetInt("language") == 2)
        {
            pauseText.text = "JOKOA GELDITUA";
            resumeText.text = "Jarraitu";
            restartText.text = "Berrabiarazi";
            returnText.text = "Menu printzipalera itzuli";
        }
        //We put the player waiting
        player.SetWait(true); 
        //Using refraction we find the keycode of the pause
        pauseKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pause"));
        //We put the final texts in blanc because we don't need them until the end of the game
        scoreText.text = "";
        scoreNumb.text = "";
        //We deactivate the pause menu
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        //When the game is starting, we put the countdown and when it finishes we start the game, spawning the coin and deactivating the waiting state
        if (starting)
        {
            if (Time.fixedTime - startTime < 3.0f)
            {
                countDown.GetComponent<TextMeshProUGUI>().text = (3 - (int)(Time.fixedTime - startTime)).ToString();
            }
            else
            {
                countDown.GetComponent<TextMeshProUGUI>().text = "";
                starting = false;
                player.SetWait(false);
                NewCoin();
            }
        }
        else
        {
            //We pause or unpause the game when the pause key is pressed, putting the player and the followers in waiting state. When the game is paused, we make the cursor visible.
            if (Input.GetKeyDown(pauseKey) && !gameEnded)
            {
                paused = !paused;
                Cursor.visible = paused;
                Time.timeScale = System.Convert.ToInt32(!paused);
                player.SetWait(paused);
                for (int i = 0; i < activeFollowers; i++) followers[i].SetWait(paused);
                pauseMenu.SetActive(paused);
            }
        }
        
    }

    //We pause the game when the player alt tabs.
    private void OnApplicationFocus(bool focus)
    {
        if (!focus && !paused && !starting)
        {
            paused = !paused;
            Cursor.visible = paused;
            Time.timeScale = System.Convert.ToInt32(!paused);
            pauseMenu.SetActive(paused);
            player.SetWait(paused);
        }
    }

    //Function to restart the level
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    //Function to open the main menu
    public void OpenMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    //Function to resume the game
    public void ResumeGame()
    {
        paused = !paused;
        Cursor.visible = paused;
        Time.timeScale = System.Convert.ToInt32(!paused);
        player.SetWait(paused);
        for (int i = 0; i < activeFollowers; i++) followers[i].SetWait(paused);
        pauseMenu.SetActive(paused);
    }

    //Function to spawn a new coin. To decide the position, we check where was the last position that a coin was spawned. If it spawned in a corner we spawn it on the other side, but if it spawned in the middle we decide where to spawn it 
    //using the random function, if it's negative to the left and if it's positive to the right. We do something pretty similar with the y coords.
    public void NewCoin()
    {
        float newX = Random.Range(-1.0f, 1.0f);
        float newY = Random.Range(-1.0f, 1.0f);
        if (lastPos.x - 1.0f < -19.0f) newX = Random.Range(lastPos.x + 1.0f, 20.0f);
        else if(lastPos.x + 1.0f > 19.0f) newX = Random.Range(-20.0f, lastPos.x - 1.0f);
        else if(newX < 0.0f) newX = Random.Range(-20.0f, lastPos.x - 1.0f);
        else newX = Random.Range(lastPos.x + 1.0f, 20.0f);
        if (lastPos.y - 1.5f < -8.8f) newY = Random.Range(lastPos.y + 1.5f, 9.8f);
        else if (lastPos.y + 1.5f > 9.8f) newY = Random.Range(-9.8f, lastPos.y - 1.5f);
        else if (newY < 0.0f) newY = Random.Range(-9.8f, lastPos.y - 1.5f);
        else newY = Random.Range(lastPos.y + 1.5f, 9.8f);
        Instantiate(coinPrefab, new Vector3(newX, newY, 0.0f), Quaternion.identity);
    }

    //Function to activate a new follower
    public void NewFollower()
    {
        //We activate a follower only if we have more followers to activate
        if (activeFollowers < followers.Length) followers[activeFollowers].ActivateFollower(); 
        activeFollowers++;
        //The score is the number of active followers
        score.GetComponent<TextMeshProUGUI>().text = activeFollowers.ToString();
    }

    //Function to save the last position of the coin
    public void SetLastPos(Vector3 last)
    {
        lastPos = last;
    }

    //Function to get if the game has ended
    public bool GetGameEnded()
    {
        return gameEnded;
    }

    //Function to end the game
    public void EndGame()
    {
        //We make the cursor visible, activate the game ended state and enable the pause menu
        Cursor.visible = true;
        gameEnded = true;
        pauseMenu.SetActive(true);
        //We deactivate all the followers
        for (int i=0; i < activeFollowers; i++) followers[i].DectivateFollower();
        //We change the texts to put the game over message and the score
        if (PlayerPrefs.GetInt("language") == 0)
        {
            pauseText.text = "GAME OVER";
            scoreText.text = "SCORE:";
        }
        else if (PlayerPrefs.GetInt("language") == 1)
        {
            pauseText.text = "HAS PERDIDO";
            scoreText.text = "PUNTUACIÓN:";
        }
        else if (PlayerPrefs.GetInt("language") == 2)
        {
            pauseText.text = "GALDU DUZU";
            scoreText.text = "PUNTUAZIOA:";
        }
        scoreNumb.text = activeFollowers.ToString();
        //We deactivate the resume button
        resumeButton.SetActive(false);
    }

}
