using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Boss : Enemy
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject player;
    private Rigidbody2D rb2d;
    
    private Animator anim;
    private SpriteRenderer _renderer;
    public HitPoints vida;

    protected override void OnWake() {

        Debug.Log("Despierta el boss");
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (!player) {
            Debug.Log("Cannot find the player");
        }

        anim = GetComponent<Animator>();

        _renderer = GetComponent<SpriteRenderer>();

        if (_renderer == null){
        Debug.LogError("Sprite is missing a renderer");
        }
    }

     protected override void OnHit(int damage) {
            Debug.Log("Golpe");
        }

        protected override void OnDie() {
            Debug.Log("Animación muerte");
            
            
            anim.SetTrigger("Die");
            
             
    }
    
    /*public void Start(){
        StartCoroutine(smallWait());
    }

    IEnumerator smallWait(){
        yield return new WaitForSeconds(1);
        vida = gameObject.GetComponent<GameEntity>().hitpoints;
        Debug.Log("hitpoints saved");
        GameObject.Find("BossHealth").GetComponent<BossHealthBar>().setHitPoints(vida);
        Debug.Log("hitpoints sent");
    }*/
        
}
