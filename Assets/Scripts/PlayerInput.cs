using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 lastPosition;

    [SerializeField] private float _runSpeed = 2;

    private float _speed = 0.1f;
    private bool _canRun = true;
    private string _tagObstacle = "Obstacle";

    // Start is called before the first frame update
    void Start()
    {
        
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
            _canRun = false;
    }
}
