using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject point;
    private int direction = 1;
    public float timer = 5;

    void Start(){
        point = GameObject.Find("player");
        if(point != null) print ("found player");
        //this.transform.rotation = point.transform.rotation;
        if (point.transform.localScale.x > 0) { 
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += -transform.right * speed * Time.deltaTime;       
        gameObject.transform.Translate(transform.TransformDirection(Vector3.left) * speed * Time.deltaTime * direction);
        timer -= 2f * Time.deltaTime;
        if(timer < 0.0f) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
        Debug.Log("OnCollisionEnter2D");

    }
}
