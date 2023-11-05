using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private static bool GamePause = false;
    [SerializeField] private GameObject pauseGame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
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
        GamePause = false;
    }
    public void Pause()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 1.0f;
        GamePause = true;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
