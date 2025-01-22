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

    public GameObject endingUI;

    private void Start()
    {
        Gas = 100;
        isGameOver = false;
        
        if (gasCountText != null)
        {
            gasCountText = GameObject.Find("[Text ] GasCountText").GetComponent<TMP_Text>();
        }
        else
        {
            gasCountText = null;
        }
        
        StartCoroutine(ConsumGas());
    }

    private void Update()
    {
        if (gasCountText != null)
        {
            GasText();
        }
        
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
        endingUI.SetActive(true);
        Debug.Log("Game Over");
    }

    void GasText()
    {
        gasCountText.text = "Gas: " + Gas.ToString();
    }
}
