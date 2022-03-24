using UnityEngine;
using UnityEngine.UIElements;
using ExtendedEditorGUI.Elements;

using Button = ExtendedEditorGUI.Elements.Button;
using Slider = ExtendedEditorGUI.Elements.Slider;
using Foldout = ExtendedEditorGUI.Elements.Foldout;
using LayerMask = ExtendedEditorGUI.Elements.LayerMask;

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
            $"{BaseStylesPath}/Elements/foldout.uss",
            $"{BaseStylesPath}/Elements/slider.uss",
            $"{BaseStylesPath}/Elements/curve.uss",
            $"{BaseStylesPath}/Elements/objectfield.uss",
            $"{BaseStylesPath}/Elements/dropdown.uss"
        };

        public static readonly string WindowStylesheet = $"{BaseStylesPath}/window.uss";
        public static readonly string InspectorStylesheet = $"{BaseStylesPath}/inspector.uss";

        public readonly VisualElement root;

        public GUI(VisualElement rootVisualElement) {
            root = rootVisualElement;
        }

        public Element<VisualElement> Element(string name) {
            return new Element<VisualElement>(name, root);
        }
        
        public Foldout Foldout(string name, FoldoutAttributes attributes = default) {
            return new Foldout(name, attributes, root);
        }
        
        public Button Button(string name) {
            return new Button(name, root);
        }
        
        public Field<TFieldType> Field<TFieldType>(string name, FieldAttributes<TFieldType> attributes = default) {
            return new Field<TFieldType>(name, attributes, root);
        }

        public Slider Slider(string name, SliderAttributes attributes = default) {
            return new Slider(name, attributes, root);
        }
        
        public Curve Curve(string name, CurveAttributes attributes = default) {
            return new Curve(name, attributes, root);
        }
        
        public LayerMask LayerMask(string name, LayerMaskAttributes attributes = default) {
            return new LayerMask(name, attributes, root);
        }

        public ObjectField<TObjectType> ObjectField<TObjectType>(string name, ObjectAttributes<TObjectType> attributes = default) where TObjectType : Object {
            return new ObjectField<TObjectType>(name, attributes, root);
        }

    }
    
}
