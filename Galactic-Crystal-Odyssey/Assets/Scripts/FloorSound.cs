using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSound : MonoBehaviour
{

    public AudioSource _audio;
    public void Start(){
        _audio = gameObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            _audio.Play();
        }
        
    } 
}
