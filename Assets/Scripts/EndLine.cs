using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    [SerializeField] private string _compareTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_compareTag))
            PlayerInput.instance.EndGame();
    }
}
