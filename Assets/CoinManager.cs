using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [SerializeField] private TextMeshProUGUI coinText;
    private int currentCoinAmount=0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCoinText();
    }

    public void IncreaseAmount(int amount)
    {
        currentCoinAmount += amount;
        UpdateCoinText();
    }

    public void DecreaseAmount(int amount)
    {
        currentCoinAmount -= amount;
        if (currentCoinAmount < 0)
        {
            currentCoinAmount = 0;
        }

        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = currentCoinAmount.ToString();
    }
}
