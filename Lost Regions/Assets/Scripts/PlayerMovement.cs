using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public CharacterController controller;
    public float walk_Speed = 6f; // walk speed
    public float run_Speed = 15f; // run speed
    public float speed = 6f;
   // public float current_Player_Speed = 6f; // current speed of player
    public Transform cam; // camera

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public GameObject Xaria_Empty; // empty gameobject
    public GameObject XariaRig; // XariaRig gameobject (model of Xaria)

    public float rotationSpeed;

    public bool player_Is_Moving;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("XariaRig").GetComponent<CharacterController>();

        cam = GameObject.Find("Main Camera").transform;
        player_Is_Moving = false;

        Xaria_Empty = GameObject.Find("Xaria");
        XariaRig = GameObject.Find("XariaRig");
    }

    // Update is called once per frame
    void Update()
    {
        // Move player
        float move_Horizontal = Input.GetAxis("Horizontal"); // returns float value between -1 and 1.  
        float move_Vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(move_Horizontal, 0.0f, move_Vertical);
        direction.Normalize(); // makes sure we have a magnitude of 1
        // movement = cam.transform.TransformDirection(movement);
        Quaternion look_At_Camera = Quaternion.LookRotation(Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up), Vector3.up); ;

        // Camera will rotate with camera
        XariaRig.transform.rotation = look_At_Camera;

        // Check if character is moving 
         if (direction != Vector3.zero)
         {
             // If moving, rotate to face direction 
             XariaRig.transform.forward = direction; // moves character in correct direction
             Xaria_Empty.transform.Translate(speed * Time.deltaTime * direction, Space.World); // moves character
         }
        
       

    }
}
