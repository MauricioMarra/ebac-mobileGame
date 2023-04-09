using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listOfPositions;

    private float _duration;

    private int _positionIndex;

    // Start is called before the first frame update
    void Start()
    {
        _positionIndex = Random.Range(0, _listOfPositions.Count);
        _duration = Random.Range(0.5f, 1.5f);

        StartCoroutine(nameof(MoveObject));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator MoveObject()
    {
        while (true)
        {
            float timeSpent = 0;
            Vector3 originalPosition = this.transform.position;

            while (timeSpent < _duration)
            {
                this.transform.position = Vector3.Lerp(originalPosition, _listOfPositions[_positionIndex].gameObject.transform.position, timeSpent / _duration);

                timeSpent += Time.deltaTime;

                yield return null;
            }

            _positionIndex++;

            if (_positionIndex >= _listOfPositions.Count)
                _positionIndex = 0;

            yield return null;
        }
    }
}
