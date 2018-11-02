using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnim : MonoBehaviour
{


    Animator j_animator;
    // Use this for initialization
    void Start()
    {
        j_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsJumpingPressed = Input.GetKeyDown("space");
        j_animator.SetBool("IsJumping", IsJumpingPressed);
    }
}
