using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public AudioSource audiosource;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField]
    public float speed = 3.00F;

    [SerializeField]
    private Transform target;

    private void Start()
    {
        
        GameIsPaused = false;
    }
    private void Awake()
    {
        if (!target) target = FindObjectOfType<Player1>().transform;
    }

    private void Update()
    {
        Vector3 position = target.position; position.z = -10.0F;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);

        if (GameIsPaused)
        {
            Cursor.visible = true;
            //audiosource.Stop();
        }
        else
        {
            Cursor.visible = false;
            //audiosource.Play();
        }

        //Pause menu and mouse
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }

            

        }
        //Gamepad menu
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }



        }


    }
    public void Resume()
    {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            audiosource.Play();
        
    }

    public void Pause()
    {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            audiosource.Stop();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    
    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting game...");
    }
   
}
