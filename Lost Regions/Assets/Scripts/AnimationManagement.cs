using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagement : MonoBehaviour
{
    // Variables
    public PlayerMovement movement_Script;
    public Animator animator;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        movement_Script = GameObject.Find("Xaria Model").GetComponent<PlayerMovement>();
        animator = GameObject.Find("XariaRig").GetComponent<Animator>();
        sword = GameObject.Find("Sword");

        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Walking state
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // player is moving!
            animator.SetBool("isWalking", true);
            movement_Script.speed = movement_Script.walk_Speed;
        }
        else
        {
            // player is not moving
            animator.SetBool("isWalking", false);
            movement_Script.speed = movement_Script.walk_Speed;
        }


        // Running state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
            movement_Script.speed = movement_Script.run_Speed;
        }
        else
        {
            animator.SetBool("isRunning", false);
            movement_Script.speed = movement_Script.walk_Speed;
        }

        
        // Sword states
        if(Input.GetKey(KeyCode.E))
        {
            // Take out sword
            animator.SetBool("takeOutSword", true);
            StartCoroutine(DelaySwordSpawn());
        }


        if(sword.activeInHierarchy == true)
        {
            // Sword is out! Player is currently holding sword

            // Check if user wants to swing sword. User presses left mouse button to swing
            if(Input.GetMouseButtonDown(0))
            {
               //Debug.Log("Player is swinging sword");
                animator.SetBool("swordSlash", true);
                Debug.Log("sword slash is run");
            }

            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(DelaySwordSwingVariable());
            }


            // Put sword away
            if (Input.GetKey(KeyCode.R))
            {
                animator.SetBool("putAwaySword", true);
                animator.SetBool("takeOutSword", false);

                sword.SetActive(false);

                StartCoroutine(DelaySwordSheathVariable());

            }
        }
    }

    /// <summary>
    /// Delays code by 1.3f seconds so that the sword spawns when the player is unsheathing the sword
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySwordSpawn()
    {
        yield return new WaitForSeconds(1.6f);
        sword.SetActive(true);
    }

    /// <summary>
    /// Delays the SwordSwing variable "swordSlash" set to false so animations runs correctly
    /// </summary>
    /// <returns></returns>
    IEnumerator DelaySwordSwingVariable()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("swordSlash", false);
    }

    IEnumerator DelaySwordSheathVariable()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("putAwaySword", false);
    }
}
