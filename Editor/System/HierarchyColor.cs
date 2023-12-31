using Unity.Mathematics;
using UnityEngine;
using UnityEditor;

namespace com.Klazapp.Editor
{
    [InitializeOnLoad]
    public class HierarchyColor
    {
        //Colors
        // private static readonly Color32 nonEmptyBackgroundColor = new Color32(52, 140, 117, 255);
        // private static readonly Color32 emptyBackgroundColor = new Color32(75, 75, 75, 255);
        // private static readonly Color32 emptyTextColor = new Color32(255, 255, 255, 255);
        //
        // private static readonly Color32 todoBackgroundColor = new Color32(155, 55, 75, 255);
        //
        // private static readonly Color32 InEditorBackgroundColor = new Color32(115, 115, 115, 255);

        private static readonly float2 offset = new float2(20, 1);

        //Subscribe to hierarchy event
        static HierarchyColor()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            //Retrieve as gameobject
            var gameObj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObj == null)
                return;

            //Retrieve original colors
            var backgroundColor = Color.white;
            var textColor = Color.white;

            //Only modify editor-only gameObj
            if (gameObj.CompareTag("EditorOnly"))
            {
                var gameObjName = gameObj.name;
                var gameObjIsStatic = gameObj.isStatic;

                if (gameObjIsStatic)
                {
                    //Set color according to if gameObj's name is empty or not
                    if (string.IsNullOrWhiteSpace(gameObjName))
                    {
                        backgroundColor = HierarchyColorComponent.emptyBackgroundColor;
                        textColor = HierarchyColorComponent.emptyTextColor;
                    }
                    else
                    {
                        backgroundColor = HierarchyColorComponent.nonEmptyBackgroundColor;
                        textColor = HierarchyColorComponent.emptyTextColor;
                    }
                }
                else
                {

                    backgroundColor = HierarchyColorComponent.InEditorBackgroundColor;
                    textColor = HierarchyColorComponent.emptyTextColor;
                }
            }
            else
            {
                if (gameObj.name.ToLower().Contains("todo"))
                {
                    backgroundColor = HierarchyColorComponent.todoBackgroundColor;
                    textColor = HierarchyColorComponent.emptyTextColor;
                }
            }

            if (backgroundColor == Color.white)
                return;

            var offsetRect = new Rect((float2)selectionRect.position + offset, selectionRect.size);
            var bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);

            EditorGUI.DrawRect(bgRect, backgroundColor);
            EditorGUI.LabelField(offsetRect, gameObj.name, new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = textColor },
                    fontStyle = FontStyle.Bold
                }
            );
        }
    }
}