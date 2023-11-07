using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool gamePause;
    public GameObject pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        pauseGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
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
        pauseGame.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }
    public void Pause()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
