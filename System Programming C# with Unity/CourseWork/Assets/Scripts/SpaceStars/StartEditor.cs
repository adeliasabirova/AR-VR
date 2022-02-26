#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Star)), CanEditMultipleObjects]
public class StarEditor : Editor
{
    private SerializedProperty _center;
    private SerializedProperty _points;
    private SerializedProperty _frequency;
    private Vector3 _pointSnap = Vector3.zero;

    private void OnEnable()
    {
        _center = serializedObject.FindProperty("Center");
        _points = serializedObject.FindProperty("Points");
        _frequency = serializedObject.FindProperty("Frequency");

        if (!serializedObject.ApplyModifiedProperties())
        {
            return;
        }
        foreach (var obj in targets)
        {
            if (obj is Star star)
            {
                star.UpdateMesh();
            }
        }
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_center);
        //EditorGUILayout.PropertyField(_points);
        EditorList.Show(_points);
        EditorGUILayout.IntSlider(_frequency, 1, 20);

        var totalPoints = _frequency.intValue * _points.arraySize;
        if (totalPoints < 3)
        {
            EditorGUILayout.HelpBox("At least three points are needed.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.HelpBox(totalPoints + " points in total.", MessageType.Info);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        if (!(target is Star star))
        {
            return;
        }
        var starTransform = star.transform;
        var angle = -360f / (star.Frequency * star.Points.Length);
        for (var i = 0; i < star.Points.Length; i++)
        {
            var rotation = Quaternion.Euler(0f, 0f, angle * i);
            var oldPoint = starTransform.TransformPoint(rotation *
            star.Points[i].Position);
            var newPoint = Handles.FreeMoveHandle(oldPoint, Quaternion.identity,
            0.02f, _pointSnap, Handles.DotHandleCap);
            if (oldPoint == newPoint)
            {
                continue;
            }
            star.Points[i].Position = Quaternion.Inverse(rotation) *
            starTransform.InverseTransformPoint(newPoint);
            star.UpdateMesh();
        }
    }
}

#endif