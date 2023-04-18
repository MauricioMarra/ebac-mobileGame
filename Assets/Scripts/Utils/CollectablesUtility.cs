using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(MyGameObjects))]
public class CollectablesUtility : Editor
{
    public override void OnInspectorGUI()
    {
        MyGameObjects myTarget = target as MyGameObjects;

        //myTarget.collectable = (GameObject)EditorGUILayout.ObjectField("Collectable", myTarget.collectable, typeof(GameObject), true);
        //myTarget.obstacle = (GameObject)EditorGUILayout.ObjectField("Obstacle", myTarget.obstacle, typeof(GameObject), true);

        myTarget.coin = (GameObject)EditorGUILayout.ObjectField("Coin", myTarget.coin, typeof(GameObject), true);

        SerializedObject so;
        SerializedProperty sp;

        so = new SerializedObject(myTarget);
        sp = so.FindProperty("collectableList");
        EditorGUILayout.PropertyField(sp, true);
        so.ApplyModifiedProperties();


        so = new SerializedObject(myTarget);
        sp = so.FindProperty("obstacleList");
        EditorGUILayout.PropertyField(sp, true);
        so.ApplyModifiedProperties();


        if (GUILayout.Button("Create Random Collectable"))
        {
            Instantiate(myTarget.collectableList.CreateRandomObjectFromList(), null);
        }        
        
        if(GUILayout.Button("Create Random Obstacle"))
        {
            Instantiate(myTarget.obstacleList.CreateRandomObjectFromList(), null);
        }
    }
}