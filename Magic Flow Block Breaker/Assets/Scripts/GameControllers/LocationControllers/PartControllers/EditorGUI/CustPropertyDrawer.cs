using UnityEditor;
using UnityEngine;

namespace GameControllers.LocationControllers.PartControllers.EditorGUI
{
    // [CustomPropertyDrawer(typeof(GamaFieldData))]
    // public class CustPropertyDrawer : PropertyDrawer 
    // {
    //     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    //     {
    //         label.text = "Level entites position";
    //         UnityEditor.EditorGUI.PrefixLabel(position, label);
    //         var newPosition = position;
    //         var data = property.FindPropertyRelative("Rows");
    //
    //         for (var j = 0; j < 5; j++)
    //         {
    //             var row = data.GetArrayElementAtIndex(j).FindPropertyRelative("RowBlocks");
    //             newPosition.height = 20f;
    //
    //             row.arraySize = 5;
    //
    //             newPosition.width = position.width / 5;
    //             for (var i = 0; i < 5; i++)
    //             {
    //                 var positionField = newPosition;
    //
    //                 positionField.y += 40f;
    //                 UnityEditor.EditorGUI.PropertyField(positionField, row.GetArrayElementAtIndex(i).FindPropertyRelative("Type"), GUIContent.none);
    //
    //                 positionField.y += 20f;
    //                 UnityEditor.EditorGUI.PropertyField(positionField, row.GetArrayElementAtIndex(i).FindPropertyRelative("AmountEntities"), GUIContent.none);
    //
    //                 newPosition.x += newPosition.width;
    //             }
    //
    //             newPosition.x = position.x;
    //             newPosition.y += 60f;
    //         }
    //     }
    //
    //     public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    //     {
    //         return 11 * 60f;
    //     }
    // }
}