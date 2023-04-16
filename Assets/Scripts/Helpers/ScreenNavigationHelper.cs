using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenNavigationHelper : MonoBehaviour
{
    public TypeOfScreen nextScreen;

    public void OnClick()
    {
        MenuManager.instance.NextScreen(nextScreen);
    }
}
