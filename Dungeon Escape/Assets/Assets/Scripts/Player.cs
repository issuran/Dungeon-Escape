﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D _rigid;
    private bool resetJumpNeeded = false;

    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private float _speed = 5.0f;
    
    void Start () {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
	}

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if (hitInfo.collider != null)
        {
            Debug.Log("Hit: " + hitInfo.collider.name);

            if (resetJumpNeeded == false)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }
}
