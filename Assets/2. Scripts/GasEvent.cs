using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasEvent : MonoBehaviour
{
    private GameManager manager;
    public int gasAmount = 30;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && manager != null)
        {
            manager.Gas  = Mathf.Min(manager.Gas + gasAmount, 100);
            
            gameObject.SetActive(false);
        }
    }
}
