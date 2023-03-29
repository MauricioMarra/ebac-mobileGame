using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 lastPosition;
    private float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - lastPosition.x);
        }
        
        lastPosition = Input.mousePosition;
    }

    void Move(float direction)
    {
        transform.position += Vector3.right * direction * Time.deltaTime * speed;
    }
}
