using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ColletCoin : MonoBehaviour
{
    public int scrore;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }

        else if(other.CompareTag("End"))
        {
            Debug.Log("Ba�ard�n!..");
            playerController.runningSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainObstacle"))
        {
            Debug.Log("�arp��ma ger�ekle�ti..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        scrore++;
        CoinText.text = "Score: " + scrore.ToString();
    }
}
