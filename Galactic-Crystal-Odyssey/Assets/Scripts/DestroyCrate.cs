using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCrate : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bullet"){
            Destroy(gameObject);
        }
        
    } 
}
