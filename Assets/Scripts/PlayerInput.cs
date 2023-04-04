using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : Singleton<PlayerInput>
{
    public Vector3 lastPosition;

    [SerializeField] private float _runSpeed;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _startScreen;

    private float _baseRunSpeed = 5;
    private float _speed = 0.1f;
    private bool _canRun = false;
    private string _tagObstacle = "Obstacle";
    private string _tagEndLine = "EndLine";

    // Start is called before the first frame update
    void Start()
    {
        ResetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;

        if(Input.GetMouseButton(0))
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
        if (other.gameObject.CompareTag(_tagObstacle))
            EndGame();

        if (other.gameObject.CompareTag(_tagEndLine))
            EndGame();
    }

    private void EndGame()
    {
        _canRun = false;
        _endScreen.SetActive(true);
    }

    public void StartGame()
    {
        _canRun = true;
        _endScreen.SetActive(false);
        _startScreen.SetActive(false);
    }

    public void SpeedUp(float value)
    {
        _runSpeed *= value;
    }

    public void ResetSpeed() 
    {
        _runSpeed = _baseRunSpeed;
    }
}
