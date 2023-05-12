using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public static bool settings = false;

    public GameObject PauseMenuUI;

    public GameObject SettingsMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if(isPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenSettings(){
        SettingsMenu.SetActive(true);
        Debug.Log("Loading Menu");
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        isPaused = false;
        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu");
    }

    public void LoadLevels(){
        Time.timeScale = 1f;
        isPaused = false;
        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene("LevelSelect");
        Debug.Log("Loading Menu");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quitting Game");
    }


    public void SettingsOff(){
        SettingsMenu.SetActive(false);
    }

}
