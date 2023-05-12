using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    public GameObject camara;
    public GameObject fondo;
    public AudioSource BossMusic;
    public float yPos = 7f;
    public GameObject objBar;
    public GameObject objPwrUP;
    public GameObject objHLT;
    public GameObject bossEnemySpawner;

    void Start(){
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            camara.transform.Translate(0f, yPos, 1f) ;
            camara.GetComponent<VerticalCamera>().statik = 1;
            camara.GetComponent<VerticalCamera>().enabled = false;
            Destroy(fondo);
            objBar.SetActive(true);
            objPwrUP.SetActive(true);
            objHLT.SetActive(true);
            bossEnemySpawner.SetActive(true);
            BossMusic.Play();           

            Destroy(gameObject);
        }
     }
}
