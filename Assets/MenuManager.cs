using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private List<ScreenBase> _listOfScreens;

    private ScreenBase _currentScreen;
    private ScreenBase _nextScreen;

    // Start is called before the first frame update
    void Start()
    {
        _currentScreen = FindScreenByType(TypeOfScreen.Start);
        _currentScreen.Show(.2f);
    }

    public ScreenBase FindScreenByType(TypeOfScreen typeOfScreen)
    {
        return _listOfScreens.Find(x => x.GetTypeOfScreen() == typeOfScreen);
    }

    public void NextScreen(TypeOfScreen typeOfScreen)
    {
        _nextScreen = FindScreenByType(typeOfScreen);

        _currentScreen.gameObject.SetActive(false);
        _nextScreen.gameObject.SetActive(true);
        _nextScreen.Show(.2f);

        _currentScreen = _nextScreen;
    }
}
