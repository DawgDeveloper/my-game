﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class jum: MonoBehaviour {
    Animator anim;

    [SerializeField]
    private float jumpForce;

    public bool grounded;

    bool jump;

    [SerializeField]
    Collider2D groundCheck;
    [SerializeField]
    LayerMask ground;

    Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = groundCheck.IsTouchingLayers(ground);

        anim.SetBool("jump", !grounded);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jump = false;

        }

    }

}
