using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D _rigid;
	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
	}
}
