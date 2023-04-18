using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBase : MonoBehaviour
{
    [SerializeField] private TypeOfScreen _screenType;

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
    void Awake()
    {
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(float delay = 0f)
    {
        int i = 0;

        //This gets every child inside this game object
        //List<Transform> listOfItem = GetComponentsInChildren<Transform>().ToList();

        //This gets only the first child of each child inside this game object.
        foreach (Transform t in transform)
        {
            t.DOScale(0, _duration).From().SetDelay(i * delay);
            i++;
        }

        i = 0;
    }

    public TypeOfScreen GetTypeOfScreen()
    {
        return _screenType;
    }
}

public enum TypeOfScreen
{
    Start,
    End,
    About
}