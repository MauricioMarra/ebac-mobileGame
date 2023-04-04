using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : CollectableBase
{
    private float _powerUpDuration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollect()
    {
        StartPowerUp();
        base.OnCollect();
    }

    private void StartPowerUp()
    {
        Debug.Log("StartPowerUp");
        Invoke(nameof(EndPowerUp), _powerUpDuration);
    }

    private void EndPowerUp()
    {
        Debug.Log("EndPowerUp");
    }
}
