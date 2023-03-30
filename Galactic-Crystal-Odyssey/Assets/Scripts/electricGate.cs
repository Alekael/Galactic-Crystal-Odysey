using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricGate : MonoBehaviour
{
    public float timer = 5f;
    public bool active = false;
    public int dmg = -1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f){ 
            active = !active; 
            timer = 5f;
        }
        if(!active){
            gameObject.GetComponent<SpriteRenderer>().enabled = active;
            gameObject.GetComponent<BoxCollider2D>().enabled = active;
        }else {
            gameObject.GetComponent<SpriteRenderer>().enabled = active;
            gameObject.GetComponent<BoxCollider2D>().enabled = active;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<PlayerMov_V2>().UpdateHealth(dmg);
        }
    }



}
