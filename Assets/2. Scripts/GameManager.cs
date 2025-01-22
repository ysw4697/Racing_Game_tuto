using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text gasCountText;
    public int Gas;
    public bool isGameOver;

    private void Start()
    {
        Gas = 100;
        isGameOver = false;
        gasCountText = GameObject.Find("[Text ] GasCountText").GetComponent<TMP_Text>();
        
        StartCoroutine(ConsumGas());
    }

    private void Update()
    {
        GasText();
        
        if (!isGameOver && Gas <= 0)
        {
            GameOver();
        }
    }

    IEnumerator ConsumGas()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            Gas -= 10;
            
            if (Gas <= 0)
            {
                Gas = 0;
                GameOver();
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
    }

    void GasText()
    {
        gasCountText.text = "Gas: " + Gas.ToString();
    }
}
