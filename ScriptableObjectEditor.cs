using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableObject), true)]
public class ScriptableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ScriptableObject scriptableObject = (ScriptableObject)target;

        if (GUILayout.Button("Generate Object ID"))
        {
            Undo.RecordObject(scriptableObject, "Generate Object ID");
            string ObjectId = System.Guid.NewGuid().ToString();
            SerializedObject serializedObject = new SerializedObject(scriptableObject);
            SerializedProperty uniqueIdProperty = serializedObject.FindProperty("objectId");
            uniqueIdProperty.stringValue = ObjectId;
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(scriptableObject);
        }
    }
}
