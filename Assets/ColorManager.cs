using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorOfObjects(ArtType artType)
    {
        foreach (var element in colorSetups)
        {
            if (element.artType == artType)
            {
                for (var i = 0; i < materials.Count; i++)
                {
                    materials[i].SetColor("_Color", element.colors[i]);
                }
            }
        }
    }
}

[Serializable]
public class ColorSetup
{
    public ArtType artType;
    public List<Color> colors;
}