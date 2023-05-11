using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    public GameObject camara;
    public GameObject fondo;
    public AudioSource BossMusic;
    public float yPos = 7f;

    void Start(){
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            camara.transform.Translate(0f, yPos, 1f) ;
            camara.GetComponent<VerticalCamera>().statik = 1;
            camara.GetComponent<VerticalCamera>().enabled = false;
            Destroy(fondo);

            BossMusic.Play();           

            Destroy(gameObject);
        }
     }
}
