using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtContainer : MonoBehaviour
{
    public GameObject artGameObject;

    public void ChangeArtGameObject(GameObject newObject)
    {
        if (artGameObject != null)
            Destroy(artGameObject);

        artGameObject = newObject;
    }
}
