using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColletCoin : MonoBehaviour
{
    public int scrore;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }

    public void AddCoin()
    {
        scrore++;
        CoinText.text = "Score: " + scrore.ToString();
    }
}
