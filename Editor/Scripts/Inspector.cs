using UnityEditor;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI {
    
    public abstract class ExtendedInspector<TClass> : Editor where TClass : class {

        protected TClass self;
        protected GUI GUI;
        
        protected abstract string path { get; }

        private void OnEnable() {
            
            this.self = target as TClass;

            GUI = new GUI(new VisualElement());

            // Define the paths for all UXML and USS assets associated with the editor window.
            var inspectorTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>($"{path}/template.uxml");
            var inspectorStylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"{path}/styles.uss");

            GUI.root.Add(inspectorTemplate.Instantiate());
            
            // Add global stylesheets to this editor window.
            foreach(var globalStylesheet in GUI.GlobalStylesheets) {
                GUI.root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(globalStylesheet));
            }
            
            // Add element stylesheets to this editor window.
            foreach(var elementStylesheet in GUI.ElementStylesheets) {
                GUI.root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(elementStylesheet));
            }
            
            GUI.root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>(GUI.InspectorStylesheet));
            
            // Add the stylesheet for this editor window.
            GUI.root.styleSheets.Add(inspectorStylesheet);
            
            OnGUI();

        }

        public override VisualElement CreateInspectorGUI() {

            return GUI.root;

        }

        /** Intentionally left blank. */
        protected virtual void OnGUI() { }

    }
    
}
