using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaFall : MonoBehaviour
{
    public GameObject tp;
   
    private void OnCollisionEnter2D(Collision2D col){
        col.transform.position = tp.transform.position;
    }     
}