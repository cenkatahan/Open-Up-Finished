﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimTransition : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S)) {

            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }

    void PerformLeftStep() {
        SoundManager.PlaySound("foot_left_step");
    }
    void PerformRightStep() {
        SoundManager.PlaySound("foot_right_step");
    }
}
