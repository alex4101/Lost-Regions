using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagement : MonoBehaviour
{
    // Variables
    public PlayerMovement movement_Script;
    public Animator animator; 

    public Animation idleAnim;
    public Animation walkAnim;
    public Animation runAnim;
    public Animation sword_UnsheathAnim;
    public Animation sword_SwingAnim;
    public Animation sword_SheathAnim;

    // Start is called before the first frame update
    void Start()
    {
        movement_Script = GameObject.Find("XariaRig").GetComponent<PlayerMovement>();
        animator = gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement_Script.player_Is_Moving == true)
        {
            // player is currently moving. Play walk animation
        }
        else
        {
            // player is currently idle. Play idle animation
        }
    }
}
