using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject controls_text;

    // Start is called before the first frame update
    void Start()
    {
        controls_text = GameObject.Find("Controls text");
        controls_text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If escape pressed, show controls again. 
        if (Input.GetKey(KeyCode.Escape))
        {
            controls_text.gameObject.SetActive(true);
        }
    }
}
