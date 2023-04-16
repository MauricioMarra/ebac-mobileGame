using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private ScreenBase _parentScreen;
    private Vector3 _originalScale;
    private Tween _currentTween;
    private float _scaleUpFactor = 1.3f;
    private float _duration = 0.4f;

    private void OnValidate()
    {
        if (GetComponent<AudioSource>() == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Awake()
    {
        _originalScale = this.transform.localScale;    
    }

    private void Start()
    {
        _parentScreen = GetComponentInParent<ScreenBase>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _currentTween = this.transform.DOScale(_originalScale * _scaleUpFactor, _duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
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
        //VFXManager.instance.PlayVfx(VfxType.Click, Input.mousePosition);
        VFXManager.instance.PlayVfx(VfxType.Click, this.transform.position);

        if (_audioClip != null && _audioSource != null)
            AudioManager.instance.PlaySingle(_audioClip, _audioSource);
    }
}
