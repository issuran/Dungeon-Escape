﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D _rigid;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool resetJumpNeeded = false;

	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        if (hitInfo.collider != null)
        {
            Debug.Log("Hit: " + hitInfo.collider.name);

            if (resetJumpNeeded == false)
            {
                _grounded = true;
            }
        }
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
	}

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }
}
