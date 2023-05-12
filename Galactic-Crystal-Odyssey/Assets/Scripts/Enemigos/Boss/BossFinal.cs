using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossFinal : MonoBehaviour
{
    void Start(){
    StartCoroutine(waiter());
    
    
    }

    void Update(){StartCoroutine(waiter());}


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("LevelSelect");

    }

}
