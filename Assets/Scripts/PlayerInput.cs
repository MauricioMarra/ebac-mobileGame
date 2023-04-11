using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : Singleton<PlayerInput>
{
    public Vector3 lastPosition;

    [SerializeField] private float _runSpeed;
    [SerializeField] private AnimatorManager _animatorManager;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _coinCollector;
    [SerializeField] private GameObject _trailRenderer;
    [SerializeField] private ParticleSystem _deathExplosion;

    private float _baseRunSpeed = 5;
    private float _speed = 0.1f;
    private bool _canRun = false;
    private bool _isInvencible = false;
    private string _tagObstacle = "Obstacle";
    private string _tagEndLine = "EndLine";
    private TextMeshPro _powerUpText;
    private Vector3 _originalPosition;
    private ScaleHelper _scaleHelper;

    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;
        _powerUpText = GetComponentInChildren<TextMeshPro>();
        _runSpeed = _baseRunSpeed;
        _scaleHelper = GetComponent<ScaleHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        _trailRenderer.SetActive(true);

        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - lastPosition.x);
        }

        lastPosition = Input.mousePosition;

        transform.Translate(Vector3.forward * Time.deltaTime * _runSpeed);
    }

    void Move(float direction)
    {
        transform.position += Vector3.right * direction * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag(_tagObstacle) && !_isInvencible && other.)
        //    EndGame();

        //if (other.gameObject.CompareTag(_tagEndLine))
        //    EndGame();
    }

    public void EndGame(bool dead = false)
    {
        _canRun = false;
        _endScreen.SetActive(true);
        _trailRenderer.SetActive(false);

        if (dead)
        {
            if(_deathExplosion != null)
                _deathExplosion.Play();

            _animatorManager.PlayAnimation(AnimatorManager.AnimationType.Death);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .3f);
        }
        else
        {
            _animatorManager.PlayAnimation(AnimatorManager.AnimationType.Idle);
        }
    }

    public void StartGame()
    {
        _canRun = true;
        _endScreen.SetActive(false);
        _startScreen.SetActive(false);

        _animatorManager.PlayAnimation(AnimatorManager.AnimationType.Run, _runSpeed);
    }

    public void SpeedUp(float value)
    {
        _runSpeed *= value;
        _animatorManager.PlayAnimation(AnimatorManager.AnimationType.Run, _runSpeed);
    }

    public void ResetSpeed() 
    {
        _runSpeed = _baseRunSpeed;
        _animatorManager.PlayAnimation(AnimatorManager.AnimationType.Run, _runSpeed);
    }

    public void SetInvencible(bool value = true)
    {
        _isInvencible = value;
    }

    public void SetPowerUpText(string text)
    {
        _powerUpText.text = text;
    }

    public void SetHeight(float value)
    {
        transform.position = new Vector3(transform.position.x, _originalPosition.y + value, transform.position.z);
    }

    public void ResetHeight()
    {
        transform.position = new Vector3(transform.position.x, _originalPosition.y, transform.position.z);
    }

    public bool IsInvencible()
    {
        return _isInvencible;
    }

    public void SetCoinCollectorSize(float value)
    {
        _coinCollector.transform.localScale = Vector3.one * value;
    }

    public void FlashPlayer()
    {
        if(_scaleHelper != null)
            _scaleHelper.FlashScale();
    }
}
