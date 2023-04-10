using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : PowerUpBase
{
    [SerializeField] private float _scale = 6.0f;

    protected override void StartPowerUp()
    {
        PlayerInput.instance.SetCoinCollectorSize(_scale);
        base.StartPowerUp();
    }

    protected override void EndPowerUp()
    {
        PlayerInput.instance.SetCoinCollectorSize(1);
        base.EndPowerUp();
    }
}
