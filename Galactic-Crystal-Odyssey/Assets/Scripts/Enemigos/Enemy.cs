using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEntity))]
public abstract class Enemy : MonoBehaviour {
    public int collisionDamage;
    public int atDmg;
    private GameEntity lifetime;
    protected abstract void OnWake();
    protected abstract void OnDie();
    protected abstract void OnHit(int damage);
    public Collider2D Atacking;
    public float maxRange;

    public bool sleeping {
        get { return !lifetime.enabled; }
    }
    void Start() {
        lifetime = GetComponent<GameEntity>();
        lifetime.OnWakeEvent += OnWake;
        lifetime.OnHitEvent += OnHit;
        lifetime.OnDieEvent += OnDie;
        lifetime.enabled = false;
    }
    private void OnDisable() {
        lifetime.OnWakeEvent -= OnWake;
        lifetime.OnHitEvent -= OnHit;
        lifetime.OnDieEvent -= OnDie;
    }
    void Atacks(){
        var heading = this.transform.position - Atacking.gameObject.transform.position;
        if (Atacking.CompareTag("Player") && !sleeping&&heading.sqrMagnitude < maxRange * maxRange) {
            var player = Atacking.gameObject.GetComponent<PlayerMov_V2>();
            player.UpdateHealth(atDmg);
            }


    }
    void OnTriggerEnter2D(Collider2D other) {
        Atacking=other;
        if (other.CompareTag("Player") && !sleeping) {
            var  player = other.gameObject.GetComponent<PlayerMov_V2>();
            player.UpdateHealth(collisionDamage);
            
        }
    }


}

