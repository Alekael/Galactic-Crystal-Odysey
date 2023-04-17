using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class flyEye : Enemy {
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

    void Update() {
        var heading = gameObject.transform.position - player.transform.position;
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);
        if (sleeping || player == null) return;
        if(heading.sqrMagnitude < maxRange/2 * maxRange/2) {
            anim.ResetTrigger("Fly");
            anim.SetTrigger("Hit");
            rb2d.velocity = direction * 0;
            return;
            }
            rb2d.velocity = direction * speed;
            anim.ResetTrigger("Hit");
            anim.SetTrigger("Fly");
            
            
          

        if ( direction.x < 0){
        _renderer.flipX = false;
        }
        else if (direction.x > 0){
        _renderer.flipX = true;
        } 
        }

        protected override void OnHit(int damage) {
            Debug.Log("flyEye hit");
            anim.SetTrigger("Hit");
        }

        protected override void OnDie() {
            Debug.Log("flyEye dies");
            
            anim.SetTrigger("Die");

        }
}

