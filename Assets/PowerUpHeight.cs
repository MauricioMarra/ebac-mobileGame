using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{
    protected override void StartPowerUp()
    {
        PlayerInput.instance.SetHeight(2);
        base.StartPowerUp();
    }

    protected override void EndPowerUp()
    {
        PlayerInput.instance.ResetHeight();
        base.EndPowerUp();
    }
}
