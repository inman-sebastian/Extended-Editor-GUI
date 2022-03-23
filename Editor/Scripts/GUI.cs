using ExtendedEditorGUI.Elements;
using UnityEngine;

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
            $"{BaseStylesPath}/Elements/helpbox.uss",
            $"{BaseStylesPath}/Elements/groupbox.uss",
            $"{BaseStylesPath}/Elements/foldout.uss"
        };

        public static readonly string WindowStylesheet = $"{BaseStylesPath}/window.uss";
        public static readonly string InspectorStylesheet = $"{BaseStylesPath}/inspector.uss";

        public readonly UnityEngine.UIElements.VisualElement root;

        public GUI(UnityEngine.UIElements.VisualElement rootVisualElement) {
            root = rootVisualElement;
        }

        public Element<UnityEngine.UIElements.VisualElement> Element(string elementName) {
            return new Element<UnityEngine.UIElements.VisualElement>(elementName, root);
        }
        
        public Button Button(string buttonName) {
            return new Button(buttonName, root);
        }
        
        public Field<TFieldType> Field<TFieldType>(string fieldName) {
            return new Field<TFieldType>(fieldName, root);
        }
        
        public Field<TFieldType> Field<TFieldType>(string fieldName, TFieldType defaultValue) {
            return new Field<TFieldType>(fieldName, defaultValue, root);
        }

        public Slider<TField> Slider<TField>(SliderAttributes<TField> attributes) {
            return new Slider<TField>(attributes, root);
        }

        public ObjectField<TObjectType> ObjectField<TObjectType>(string fieldName) where TObjectType : Object {
            return new ObjectField<TObjectType>(fieldName, root);
        }
        
        public ObjectField<TObjectType> ObjectField<TObjectType>(string fieldName, TObjectType defaultValue) where TObjectType : Object {
            return new ObjectField<TObjectType>(fieldName, defaultValue, root);
        }
        
    }
    
}
