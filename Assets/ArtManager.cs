using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
    public List<ArtSetup> setups;

    public GameObject GetArtByType(ArtType type)
    {
        foreach (var element in setups)
            if (element.artType == type) return element.artObject;

        return null;
    }
}

public enum ArtType
{
    ArtType_01,
    ArtType_02
}

[Serializable]
public class ArtSetup
{
    public ArtType artType;
    public GameObject artObject;
}
