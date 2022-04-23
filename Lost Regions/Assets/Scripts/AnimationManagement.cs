using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagement : MonoBehaviour
{
    // Variables
    public PlayerMovement movement_Script;
    public Animator animator;

   // public Animation idleAnim;
   // public Animation walkAnim;
   // public Animation runAnim;
   // public Animation sword_UnsheathAnim;
   // public Animation sword_SwingAnim;
   // public Animation sword_SheathAnim;

    // Start is called before the first frame update
    void Start()
    {
        movement_Script = GameObject.Find("XariaRig").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Walking state
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            // player is moving!
            animator.SetBool("isWalking", true);
            movement_Script.current_Player_Speed = movement_Script.walk_Speed;
        }
        else
        {
            // player is not moving
            animator.SetBool("isWalking", false);
            movement_Script.current_Player_Speed = movement_Script.walk_Speed;
        }

        // Running state
        if (Input.GetKey("left shift"))
        {
            animator.SetBool("isRunning", true);
            movement_Script.current_Player_Speed = movement_Script.run_Speed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            movement_Script.current_Player_Speed = movement_Script.walk_Speed;
        }

        if (movement_Script.player_Is_Moving == true)
        {
            // player is currently moving. Play walk animation

        }
        else
        {
            // player is currently idle. Play idle animation
        }
    }
}
