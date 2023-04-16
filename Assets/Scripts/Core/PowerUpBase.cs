using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    private float _powerUpDuration = 2.0f;

    protected override void OnCollect()
    {
        PlayerInput.instance.FlashPlayer();
        StartPowerUp();
        base.OnCollect();
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), _powerUpDuration);
    }

    protected virtual void EndPowerUp()
    {
        
    }
}
