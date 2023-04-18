using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class UtilsExtension
{
    public static T CreateRandomObjectFromList<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    #if UNITY_EDITOR
        [UnityEditor.MenuItem("MyUtilities/Create Cube")]
        public static void CreateCoin()
        {
            var o = GameObject.CreatePrimitive(PrimitiveType.Cube);
            o.transform.position = Vector3.zero;
        }
    #endif
}
