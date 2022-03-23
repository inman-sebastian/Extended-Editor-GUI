using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI {

    public struct Panel {
        public Type type;
        public Docker.DockPosition position;
    }
    
    public abstract class ExtendedWindow<T> : EditorWindow where T : EditorWindow {

        private bool m_ready = false;
        
        private bool m_loadedPanels = false;
        
        public static ExtendedWindow<T> Window;
        protected GUI GUI;
        
        protected new abstract string title { get; }
        protected abstract string path { get; }
        
        protected virtual List<Panel> panels => new List<Panel>();

        protected virtual bool includeTemplateFiles => true;
        
        public static void OpenWindow(bool utility = false, bool focus = true) {
            Window = GetWindow<T>(utility, "", focus) as ExtendedWindow<T>;
        }

        private void OnGUI() {

            if (!m_ready) {
                
                titleContent = new GUIContent { text = title };
                
                if (panels.Count > 0 && !m_loadedPanels) {
                
                    foreach (var panel in panels) {
                        var window = GetWindow(panel.type);
                        this.Dock(window, panel.position);
                    }

                    m_loadedPanels = true;
                
                }

                m_ready = true;
                
                OnReady();

            }
            
            OnUpdate();
            
        }

        private void CreateGUI() {
            
            if (!includeTemplateFiles) return;
            
            GUI = new GUI(rootVisualElement);

            // Define the paths for all UXML and USS assets associated with the editor window.
            var windowTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>($"{path}/template.uxml");
            var windowStylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"{path}/styles.uss");
            
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
