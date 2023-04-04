using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    private float _powerUpDuration = 2.0f;

    protected override void OnCollect()
    {
        StartPowerUp();
        base.OnCollect();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("StartPowerUp");
        Invoke(nameof(EndPowerUp), _powerUpDuration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("EndPowerUp");
    }
}
