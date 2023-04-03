using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public Sprite texture;
    public int wallHP = 2;

    private void OnCollisionEnter2D(Collision2D col){
        
        if(col.gameObject.tag == "Bullet"){
            WallHealth(col.gameObject.GetComponent<Bullet>().damage);
        }

        if(wallHP <= 0){
            Destroy(gameObject);
            //Debug.Log("wall break");

        }
        if(wallHP < 2){
            gameObject.GetComponent<SpriteRenderer>().sprite = texture;
            //Debug.Log(wallHP);
        }
        
    }

    private void WallHealth(int dmg){
        wallHP -= dmg;
    }       
}
