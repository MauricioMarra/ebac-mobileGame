using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [SerializeField] private float _speedFactor = 2.0f;

    protected override void StartPowerUp()
    {
        PlayerInput.instance.SpeedUp(_speedFactor);
        base.StartPowerUp();
    }

    protected override void EndPowerUp()
    {
        PlayerInput.instance.ResetSpeed();
        base.EndPowerUp();
    }
}
