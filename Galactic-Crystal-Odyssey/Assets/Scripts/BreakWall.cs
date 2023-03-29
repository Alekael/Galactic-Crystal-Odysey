using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public Sprite texture;
    public int i = 0;

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Bullet" && i >= 1){
            Destroy(gameObject);
            Debug.Log("wall break");

        }
        if(col.gameObject.tag == "Bullet" && i < 1){
            gameObject.GetComponent<SpriteRenderer>().sprite = texture;
            i++;
            Debug.Log(i);
        }
        
    }       
}
