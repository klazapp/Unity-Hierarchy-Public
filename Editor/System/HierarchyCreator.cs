using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.Klazapp.Editor
{
    public class HierarchyCreator : EditorWindow
    {
        #region Textures
        public Texture hierarchyCreatorIcon;
        #endregion

        private string inputText = "";
        
        [MenuItem("Klazapp/Tools/Hierarchy Creator")]
        private static void ShowWindow()
        {
            //Retrieve inspector window
            var inspectorWindowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");

            //Dock beside inspector window
            EditorWindow window = GetWindow<HierarchyCreator>(inspectorWindowType);

            //Show content
            //Hardcoded strings due to static function
            var icon = AssetDatabase.LoadAssetAtPath<Texture>(
                "Packages/com.klazapp.hierarchy/Editor/Data/Hierarchy Icon.png");
            var titleContent = new GUIContent("Hierarchy Creator", icon);
            window.titleContent = titleContent;
        }

        private void OnEnable()
        {
            inputText = "";
        }

        private void OnGUI()
        {
            //Store default color
            var defaultBgColor = GUI.backgroundColor;

            EditorGUILayout.Space(30f);

            DrawTitle();
            
            EditorGUILayout.Space(10f);
            
            CustomEditorHelper.DrawHorizontalLine();

            EditorGUILayout.Space(30f);

            DrawInputField();
            
            EditorGUILayout.Space(30f);

            DrawPreview();
            
            EditorGUILayout.Space(50f);

            DrawCreate();
            
            if (CustomEditorHelper.OnPointerDownInLastRect())
            {
                CreateHierarchy();
            }
            return;

            #region Local Functions
            void DrawTitle()
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(hierarchyCreatorIcon, GUILayout.Width(30), GUILayout.Height(30));
                var labelFieldStyle = new GUIStyle()
                {
                    fontSize = 30,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true,
                    normal =
                    {
                        textColor = Color.white
                    }
                };
                EditorGUILayout.LabelField("Hierarchy Creator", labelFieldStyle, GUILayout.ExpandWidth(true));
                EditorGUILayout.EndHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }

            void DrawInputField()
            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();
                EditorGUILayout.Space(20);
                var inputFieldLabelStyle = new GUIStyle()
                {
                    fontSize = 15,
                    fontStyle = FontStyle.Normal,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true,
                    normal =
                    {
                        textColor = Color.white
                    }
                };
                EditorGUILayout.LabelField("Type your hierarchy creator here:", inputFieldLabelStyle, GUILayout.ExpandWidth(true));
                EditorGUILayout.Space(10);
                inputText = EditorGUILayout.TextField("", inputText, GUILayout.Height(20));
                EditorGUILayout.Space(20);
                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            
            void DrawPreview()
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();
                var previewLabelStyle = new GUIStyle()
                {
                    fontSize = 15,
                    fontStyle = FontStyle.Normal,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true,
                    normal =
                    {
                        textColor = Color.white
                    }
                };
                EditorGUILayout.LabelField("Preview", previewLabelStyle, GUILayout.ExpandWidth(true));
                EditorGUILayout.Space(10);
         
                var titleStyle = new GUIStyle()
                {
                    alignment = TextAnchor.MiddleCenter,
                    normal = new GUIStyleState()
                    {
                        textColor = Color.white,
                    },
                    wordWrap = true,
                };
                
                var textureStyle = new GUIStyle()
                {
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true,
                };

                CustomEditorHelper.DrawBox(250, 15, HierarchyColorComponent.emptyBackgroundColor, "", titleStyle);
                CustomEditorHelper.DrawBox(250, 15, HierarchyColorComponent.emptyBackgroundColor, "", titleStyle);
                CustomEditorHelper.DrawBox(250, 15, HierarchyColorComponent.nonEmptyBackgroundColor, inputText.ToUpper(), titleStyle);      

                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }
            
            void DrawCreate()
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical("helpbox", GUILayout.Width(200), GUILayout.Height(60));
                var previewLabelStyle = new GUIStyle()
                {
                    fontSize = 16,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter,
                    wordWrap = true,
                    normal =
                    {
                        textColor = Color.white
                    }
                };
                EditorGUILayout.LabelField("CREATE", previewLabelStyle, GUILayout.ExpandWidth(true), GUILayout.Height(60));
                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();
            }

            void CreateHierarchy()
            {
                var emptyObj1 = new GameObject()
                {
                    tag = "EditorOnly",
                    name = "",
                    isStatic = true,
                };
                
                var emptyObj2 = new GameObject()
                {
                    tag = "EditorOnly",
                    name = "",
                    isStatic = true,
                };

                var hierarchyObj = new GameObject()
                {
                    tag = "EditorOnly",
                    name = "                  " + inputText.ToUpper(),
                    isStatic = true,
                };
                
                EditorUtility.SetDirty(this);
                var activeScene = SceneManager.GetActiveScene();
                EditorSceneManager.MarkSceneDirty(activeScene);
                EditorSceneManager.SaveScene(activeScene);
            }
            #endregion
        }
    }
}
