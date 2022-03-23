using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI {
    
    public abstract class ExtendedWindow<T> : EditorWindow where T : EditorWindow {

        private bool m_ready = false;
        
        public static ExtendedWindow<T> Window;
        protected GUI GUI;
        
        protected new abstract string title { get; }

        protected virtual bool includeTemplateFiles => true;
        
        public static void OpenWindow(bool utility = false, bool focus = true) {
            Window = GetWindow<T>(utility, "", focus) as ExtendedWindow<T>;
        }

        private void OnGUI() {

            if (!m_ready) {
                
                titleContent = new GUIContent { text = title };

                m_ready = true;
                
                OnReady();

            }
            
            OnUpdate();
            
        }

        private void CreateGUI() {
            
            if (!includeTemplateFiles) return;
            
            GUI = new GUI(rootVisualElement);
            
            // Programatically get the path of the editor window.
            var self = MonoScript.FromScriptableObject(this);
            var path = AssetDatabase.GetAssetPath(self).Replace(".cs", "");
            
            // Define the paths for all UXML and USS assets associated with the editor window.
            var windowTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>($"{path}.uxml");
            var windowStylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"{path}.uss");
            
            // Add the template for this editor window.
            rootVisualElement.Add(windowTemplate.Instantiate());
            
            // Add global stylesheets to this editor window.
            foreach(var globalStylesheet in GUI.GlobalStylesheets) {
                rootVisualElement.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(globalStylesheet));
            }
            
            // Add element stylesheets to this editor window.
            foreach(var elementStylesheet in GUI.ElementStylesheets) {
                rootVisualElement.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(elementStylesheet));
            }
            
            rootVisualElement.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(GUI.WindowStylesheet));
            
            // Add the stylesheet for this editor window.
            rootVisualElement.styleSheets.Add(windowStylesheet);
            
        }

        /** Intentionally left blank. */
        protected virtual void OnReady() { }
        
        /** Intentionally left blank. */
        protected virtual void OnUpdate() { }
    
    }
    
}
