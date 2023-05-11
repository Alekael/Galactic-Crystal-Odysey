using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    public GameObject camera;
    public GameObject fondo;
    // Start is called before the first frame update
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            
            GameObject camara = Instantiate(camera);
            camara.GetComponent<VerticalCamera>().yAxis = 41.5f;
            camara.GetComponent<VerticalCamera>().statik = 1;
            Destroy(fondo);


            Destroy(gameObject);
        }
     }
}
