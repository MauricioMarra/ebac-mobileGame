using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Vector3 _originalScale;
    private Tween _currentTween;
    private float _scaleUpFactor = 1.3f;
    private float _duration = 0.4f;
    private bool _isButtonClicked = false;

    private void Start()
    {
        _originalScale = this.transform.localScale;
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

    private void ScaleDownButton()
    {
        this.transform.DOScale(Vector3.zero, _duration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isButtonClicked = true;

        if (_currentTween != null)
            _currentTween.Kill();

        ScaleDownButton();
    }
}
