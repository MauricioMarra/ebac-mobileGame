using System;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOCollectables coins;
    public Action OnChangeValues;

    private void Start()
    {
        coins.value = 0;
        this.OnChangeValues.Invoke();
    }

    public void AddCoin(int amount = 1)
    {
        coins.value += amount;

        OnChangeValues.Invoke();
    }
}
