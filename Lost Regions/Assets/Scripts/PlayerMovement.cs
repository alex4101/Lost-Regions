using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public CharacterController controller;
    public float speed = 6f;
    public Transform cam; // camera

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public bool player_Is_Moving;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        cam = GameObject.Find("Main Camera").transform;
        player_Is_Moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // outputs -1 or 1.   -1 = A or Left arrow key. 1 for D or right arrow
        float vertical = Input.GetAxisRaw("Vertical"); // outputs -1 or 1.   -1 = W key or up arrow. 1 = S key or down arrow.
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // player is moving
            player_Is_Moving = true;

            // we have input to move
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // used to rotate character towards movement
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move character
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        else
        {
            // player stopped moving
            player_Is_Moving = false;
        }
    }
}
