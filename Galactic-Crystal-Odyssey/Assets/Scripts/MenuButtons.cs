using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class MenuButtons : MonoBehaviour
{
    public Button jugarButton, creditosButton, salirButton;
    // Start is called before the first frame update
    void Start()
    {
        jugarButton.onClick.AddListener(Jugar);
        creditosButton.onClick.AddListener(Creditos);
        salirButton.onClick.AddListener(Salir);

    }

    void Jugar()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    void Creditos(){
        SceneManager.LoadScene("Creditos");
    }

    void Salir(){
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}