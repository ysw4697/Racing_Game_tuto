using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerCarMove : MonoBehaviour
{
    private GameManager manager;
    private Rigidbody rb;
    
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isGameOver)
        {
            return;
        }
        
        Move();
    }

    void Move()
    {
        if (manager.isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.MovePosition(rb.transform.position + new Vector3(- 1.0f, 0, 0));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rb.MovePosition(rb.transform.position + new Vector3( 1.0f, 0, 0));
            }
        }
    }
}
