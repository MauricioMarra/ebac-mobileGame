using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private ScreenBase _parentScreen;
    private Vector3 _originalScale;
    private Tween _currentTween;
    private float _scaleUpFactor = 1.3f;
    private float _duration = 0.4f;
    private bool _isButtonClicked = false;

    private void Awake()
    {
        _originalScale = this.transform.localScale;    
    }

    private void Start()
    {
        _parentScreen = GetComponentInParent<ScreenBase>();
    }

    private void OnDisable()
    {
        _isButtonClicked = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isButtonClicked)
            _currentTween = this.transform.DOScale(_originalScale * _scaleUpFactor, _duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isButtonClicked)
            _currentTween = this.transform.DOScale(_originalScale, _duration);
    }

    public void ScaleDownButton(float delay = 0)
    {
        this.transform.DOScale(Vector3.zero, _duration).SetDelay(delay);
    }

    public void ScaleUpButton(float delay = 0)
    {
        this.transform.DOScale(_originalScale, _duration).SetDelay(delay);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isButtonClicked = true;

        //if (_currentTween != null)
        //    _currentTween.Kill();

        //ScaleDownButton();

        //_parentScreen.Close(_duration);
    }
}
