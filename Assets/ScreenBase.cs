using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBase : MonoBehaviour
{
    [SerializeField] public TypeOfScreen _screenType { get; private set; }

    private List<Button> _listOfButtons = new List<Button>();
    private Vector3 _originalScale;
    private float _duration = 0.4f;

    private void OnValidate()
    {
        _listOfButtons = this.transform.GetComponentsInChildren<Button>().ToList();

        foreach (Button button in _listOfButtons)
        {
            if (button.GetComponent<ButtonHelper>() == null)
                button.AddComponent<ButtonHelper>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        this.transform.DOScale(_originalScale, _duration);
    }

    public void Close(float delay = 0f)
    {
        this.transform.DOScale(Vector3.zero, _duration).SetDelay(delay);
    }
}

public enum TypeOfScreen
{
    Start,
    End,
    About
}