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
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }

        else if(other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.y, Space.Self);
            EndPanel.SetActive(true);

            if(scrore >= maxScore)
            {
                //Debug.Log("You Win!");
                PlayerAnim.SetBool("win", true);
            }

            else
            {
                //Debug.Log("You Lose!");
                PlayerAnim.SetBool("lose", true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MainObstacle"))
        {
            Debug.Log("Çarpýþma gerçekleþti..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        scrore++;
        CoinText.text = "Score: " + scrore.ToString();
    }
}
