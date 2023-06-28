using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gallery
{
    [CustomEditor(typeof(SystemInputsLocal))]
    public class SystemInputsLocalInspector : Editor
    {
        private SerializedProperty _backButtonOption;
        private SerializedProperty _sceneToLoadData;

        private void OnEnable()
        {
            _backButtonOption = serializedObject.FindProperty("_backButtonOption");
            _sceneToLoadData = serializedObject.FindProperty("_sceneToLoadData");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_backButtonOption);

            if (_backButtonOption.enumValueIndex == (int)GoToPreviousSceneVariants.CustomSceneLoader)
            {
                EditorGUILayout.PropertyField(_sceneToLoadData);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
