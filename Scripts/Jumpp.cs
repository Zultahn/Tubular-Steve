﻿using UnityEngine;

public class Jumpp : MonoBehaviour {

    public float fallMult = 2.5f;
    public float lowJumpMult = 2f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(rb.velocity.y<0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMult - 1) * Time.deltaTime;
        }else if (rb.velocity.y>0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
        }

    }
}
