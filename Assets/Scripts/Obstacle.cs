using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private string _compareTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_compareTag) && !PlayerInput.instance.IsInvencible())
            PlayerInput.instance.EndGame(true);
    }
}
