using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleHelper : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private float _flashDuration = .2f;
    [SerializeField] private float _flashScaleFactor = 1.2f;

    private Vector3 _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScalePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ScalePlayer()
    {
        this.transform.DOScale(_originalScale, _duration);
    }

    public void FlashScale()
    {
        this.transform.DOScale(_originalScale * _flashScaleFactor, _flashDuration).SetLoops(2, LoopType.Yoyo);
    }
}
