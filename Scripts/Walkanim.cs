using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Walkanim : MonoBehaviour {
    public CapsuleCollider player;

    Animator m_animator;
	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        player = player.GetComponent<CapsuleCollider>();
       
    }
	
	// Update is called once per frame
	void Update () {
        bool IsWalkingPressed = Input.GetKey("w");
        m_animator.SetBool("IsWalking", IsWalkingPressed);
        bool IsLeftPressed = Input.GetKey("a");
        m_animator.SetBool("IsLeft", IsLeftPressed);
        bool IsRightPressed = Input.GetKey("d");
        m_animator.SetBool("IsRight", IsRightPressed);
        bool IsBackPressed = Input.GetKey("s");
        m_animator.SetBool("IsBack", IsBackPressed);
        bool IsBoogyPressed = Input.GetKey("e");
        m_animator.SetBool("IsBoogy", IsBoogyPressed);
        
        if(Input.GetKey("e"))
        {
            player.height = 1f;
            player.center = new Vector3(0, .5f, 0);
        
        }
        else
        {
            player.height = 2.104244f;
            player.center = new Vector3(0.007243454f, 0.9895918f, -0.1530654f);
        }
       
        
    }
}
