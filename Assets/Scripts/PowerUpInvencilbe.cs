using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencilbe : PowerUpBase
{
    protected override void StartPowerUp()
    {
        PlayerInput.instance.SetInvencible();
        PlayerInput.instance.SetPowerUpText("Invencible");
        base.StartPowerUp();
    }

    protected override void EndPowerUp()
    {
        PlayerInput.instance.SetInvencible(false);
        PlayerInput.instance.SetPowerUpText(string.Empty);

        base.EndPowerUp();
    }
}
