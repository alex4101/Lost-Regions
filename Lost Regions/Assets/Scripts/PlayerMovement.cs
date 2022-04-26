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
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        direction.Normalize(); // makes sure we have a magnitude of 1

        // Check if character is moving 
        if(direction != Vector3.zero)
        {
            // Uf moving, rotate to face direction 
            Xaria_Empty.transform.Translate(speed * Time.deltaTime * direction, Space.World);
            XariaRig.transform.forward = direction;

           // XariaRig.transform.position = XariaRig.transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }

    }
}
