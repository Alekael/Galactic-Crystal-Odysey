using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");

    }
}
