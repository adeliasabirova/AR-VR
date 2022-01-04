using UnityEditor;
using UnityEngine;

public static class EditorList
{
	private static GUIContent
		moveButtonContent = new GUIContent("\u21b4", "move down"),
		duplicateButtonContent = new GUIContent("+", "duplicate"),
		deleteButtonContent = new GUIContent("-", "delete"),
		addButtonContent = new GUIContent("+", "add element");

	private static GUILayoutOption miniButtonWidth = GUILayout.Width(20f);

	public static void Show(SerializedProperty list)
	{
		EditorGUILayout.LabelField(list.displayName);
		EditorGUI.indentLevel += 1;
		SerializedProperty size = list.FindPropertyRelative("Array.size");
		EditorGUILayout.PropertyField(size);
		if (size.hasMultipleDifferentValues)
		{
			EditorGUILayout.HelpBox("Not showing lists with different sizes.", MessageType.Info);
		}
		else
		{

			for (int i = 0; i < list.arraySize; i++)
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
				ShowButtons(list, i);
				EditorGUILayout.EndHorizontal();
			}

			if (list.arraySize == 0 && GUILayout.Button(addButtonContent, EditorStyles.miniButton))
			{
				list.arraySize += 1;
			}
		}

		EditorGUI.indentLevel -= 1;
		
	}

	private static void ShowButtons(SerializedProperty list, int index)
	{
		if (GUILayout.Button(moveButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth))
		{
			list.MoveArrayElement(index, index + 1);
		}
		if (GUILayout.Button(duplicateButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
		{
			list.InsertArrayElementAtIndex(index);
		}
		if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
		{
			int oldSize = list.arraySize;
			list.DeleteArrayElementAtIndex(index);
			if (list.arraySize == oldSize)
			{
				list.DeleteArrayElementAtIndex(index);
			}
		}
	}
}