using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gallery
{
    [CustomEditor(typeof(GridParametersCalculator))]
    public class GridParamteresCalculatorInspector: Editor
    {
        private SerializedProperty _canvas;
        private SerializedProperty _forceParticularOriantationCalculation;
        private SerializedProperty _forcedOrientation;

        private void OnEnable()
        {
            _canvas = serializedObject.FindProperty("_canvas");
            _forceParticularOriantationCalculation = serializedObject.FindProperty("_forceParticularOriantationCalculation");
            _forcedOrientation = serializedObject.FindProperty("_forcedOrientation");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_canvas);
            EditorGUILayout.PropertyField(_forceParticularOriantationCalculation);

            if (_forceParticularOriantationCalculation.boolValue)
            {
                EditorGUILayout.PropertyField(_forcedOrientation);
            }

            serializedObject.ApplyModifiedProperties();
        }

    }
}
