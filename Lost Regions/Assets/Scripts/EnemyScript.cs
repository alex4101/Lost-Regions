using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("Sword");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision entered");
        Debug.Log(collision.gameObject.name);

        // Check if sword is out. 
        if(sword.activeInHierarchy)
        {
            // Check for collision. If detected, delete enemy
            if (collision.gameObject.name == "Sword" || collision.gameObject.name == "XariaRig")
            {
                // Destory enemy! They have collided with the sword
                Destroy(gameObject);
                Debug.Log("Sword has collided!");
            }
        }
        else
        {
            // Do nothing. You need the sword to be out to kill the enemy
        }

        
    }
}
