using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(4);
        EditorApplication.isPlaying = false; 
    }
}