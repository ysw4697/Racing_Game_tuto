using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMap : MonoBehaviour
{
    private GameManager manager;
    
    public float offsetSpeed;
    public float width;
    
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        
        offsetSpeed = 25.0f;
        width = 25.0f;
    }

    void Update()
    {
        if (manager.isGameOver)
        {
            return;
        }

        float offset = offsetSpeed * Time.deltaTime;
        gameObject.transform.position += new Vector3(0, 0, -offset);

        if (gameObject.transform.position.z <= -width)
        {
            Vector3 newPosition = transform.position;
            newPosition.z += width * 2;
            transform.position = newPosition;
        }
    }
}
