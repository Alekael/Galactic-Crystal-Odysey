using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class Slime : Enemy {
    private GameObject player;
    private Rigidbody2D rb2d;
    public float speed;
    private Animator anim;
    private SpriteRenderer _renderer;
  

    protected override void OnWake() {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (!player) {
            Debug.LogError("Cannot find the player");
        }
        anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();

        if (_renderer == null){
        Debug.LogError("Sprite is missing a renderer");
        }
    }
    void Atacks(){
        var heading = this.transform.position - Atacking.gameObject.transform.position;
        if (Atacking.CompareTag("Player") && !sleeping && heading.sqrMagnitude < maxRange * maxRange) {
            var player = Atacking.gameObject.GetComponent<PlayerMov_V2>();
            player.UpdateHealth(atDmg);
            }
        
        }

    void Update() {
        player = GameObject.FindGameObjectWithTag("Player");
        var heading = gameObject.transform.position - player.transform.position;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        if (sleeping || player == null) return;
        if(heading.sqrMagnitude < maxRange/2 * maxRange/2) {
            Debug.Log("Entro a rango");
            anim.ResetTrigger("Move");
            anim.SetTrigger("Hit");
            rb2d.velocity = direction * 0;
            return;
            }
            direction.y=0;
            rb2d.velocity = direction * speed;
            anim.ResetTrigger("Hit");
            anim.SetTrigger("Move");
            
            
          

        if ( direction.x < 0){
        _renderer.flipX = false;
        }
        else if (direction.x > 0){
        _renderer.flipX = true;
        } 
        }

        protected override void OnHit(int damage) {
            Debug.Log("Slime hit");
            anim.SetTrigger("Hit");
        }

        protected override void OnDie() {
            Debug.Log("Slime dies");
            
            anim.SetTrigger("Die");

        }
}
