using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSelectHelper : MonoBehaviour
{
    [SerializeField] private GameObject _powerUp;
    [SerializeField] private List<GameObject> _powerUpList;

    // Start is called before the first frame update
    void Start()
    {
        if (_powerUp != null)
            Destroy(_powerUp);

        _powerUp = Instantiate(_powerUpList[Random.Range(0, _powerUpList.Count)], this.transform);
    }
}
