using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public int amount = 10;

    public void Collect()
    {
        CoinManager.instance.IncreaseAmount(amount);
        Destroy(gameObject); 
    }
}
