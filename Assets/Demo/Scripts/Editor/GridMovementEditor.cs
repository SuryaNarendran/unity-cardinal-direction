using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridMovement))]
public class GridMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        DrawDefaultInspector();
        if (EditorGUI.EndChangeCheck())
        {
            GridMovement gm = target as GridMovement;
            gm.transform.localRotation = gm.myDirection.AsRotation;
        }
    }
}
