using System.Collections;
using UnityEditor;
using UnityEngine;
namespace Scripts.GameBoardLogic
{
    [CustomEditor(typeof(Grid))]
    public class GridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var grid = target as Grid;

            DrawDefaultInspector();

            EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Create"))
            {
                grid.Create();
            }
            if (GUILayout.Button("Clear"))
            {
                grid.Clear();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}
