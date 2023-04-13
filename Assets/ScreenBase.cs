using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBase : MonoBehaviour
{
    private List<Button> _listOfButtons = new List<Button>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
