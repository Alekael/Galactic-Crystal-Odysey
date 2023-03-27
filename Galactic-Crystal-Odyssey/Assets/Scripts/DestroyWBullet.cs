using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWBullet : MonoBehaviour
{

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col){
       
        if(col.gameObject.CompareTag("Bullet")){
            Debug.Log("bullet col");
            Destroy(gameObject);
        }
    }
}
