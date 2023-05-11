using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOff : MonoBehaviour
{
    public AudioSource levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        levelMusic.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelMusic.Pause();           
            Destroy(gameObject);
        }
     }
}
