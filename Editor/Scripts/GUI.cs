using UnityEngine.UIElements;

namespace ExtendedEditorGUI {

    public class GUI {

        private const string BaseStylesPath = "Packages/com.sebastian-inman.extended-editor-gui/Editor/Styles";

        public static readonly string[] GlobalStylesheets = {
            $"{BaseStylesPath}/Global/variables.uss",
            $"{BaseStylesPath}/Global/helpers.uss"
        };

        public static readonly string[] ElementStylesheets = {
            $"{BaseStylesPath}/Elements/field.uss",
            $"{BaseStylesPath}/Elements/button.uss",
            $"{BaseStylesPath}/Elements/colorfield.uss",
            $"{BaseStylesPath}/Elements/helpbox.uss"
        };

        public static readonly string WindowStylesheet = $"{BaseStylesPath}/window.uss";
        public static readonly string InspectorStylesheet = $"{BaseStylesPath}/inspector.uss";

        public readonly VisualElement root;

        public GUI(VisualElement rootVisualElement) {
            
            root = rootVisualElement;
            
        }

        public Elements.Element<VisualElement> Element(string elementName) {
            return new Elements.Element<VisualElement>(elementName, root);
        }
        
        public Elements.Button Button(string buttonName) {
            return new Elements.Button(buttonName, root);
        }
        
        public Elements.Field<TFieldType> Field<TFieldType>(string fieldName) {
            return new Elements.Field<TFieldType>(fieldName, root);
        }
        
        public Elements.Field<TFieldType> Field<TFieldType>(string fieldName, TFieldType defaultValue) {
            return new Elements.Field<TFieldType>(fieldName, defaultValue, root);
        }
        
    }
    
}
