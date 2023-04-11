using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    [Header("Collect Config")]
    public int collectAmount;

    private Animator _animator;
    private string _coinTrigger = "collect";

    [SerializeField] ParticleSystem _collectVFX;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnCollect()
    {
        if(_collectVFX != null)
            _collectVFX.Play();

        PlayerInput.instance.FlashPlayer();

        base.OnCollect();

        ItemManager.instance.AddCoin(collectAmount);

        if (_animator != null)
            _animator.SetTrigger(_coinTrigger);
    }
}
