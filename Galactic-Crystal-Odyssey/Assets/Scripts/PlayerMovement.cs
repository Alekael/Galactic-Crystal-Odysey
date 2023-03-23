using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.5f;
    private Rigidbody2D _body;
    private Animator _anim;
    public float jumpForce = 10.0f;
    public float lastY;
    
    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0f)) {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1f, 1f);
        }

        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        if (Input.GetButtonDown("Jump") && _anim.GetBool("isGrounded")) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _anim.SetBool("isGrounded", false);
        }

    
        if(_body.velocity.y == 0) {
            _anim.SetBool("isGrounded", true);
            _anim.SetBool("isFalling", false);
        } 

         if(_body.velocity.y < lastY) {
            _anim.SetBool("isFalling", true);
        } 
        lastY = transform.position.y;
    }
}
