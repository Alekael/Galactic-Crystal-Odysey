using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    //public GameObject breakableWall;
    

    private void OnTriggerEnter2D(Collider2D col){
        //Instantiate(breakableWall, transform.position, transform.rotation);
        if(col.gameObject.tag == "Bullet")
        Destroy(gameObject);
    }
}
