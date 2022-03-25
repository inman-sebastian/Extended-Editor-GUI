using System;
using UnityEngine.UIElements;
using ExtendedEditorGUI.Elements;
using UnityEngine;
using Button = ExtendedEditorGUI.Elements.Button;
using Slider = ExtendedEditorGUI.Elements.Slider;
using Foldout = ExtendedEditorGUI.Elements.Foldout;
using LayerMask = ExtendedEditorGUI.Elements.LayerMask;
using Object = UnityEngine.Object;

namespace ExtendedEditorGUI {

    public class GUI {

        private const string BaseStylesPath = "Packages/com.sebastian-inman.extended-editor-gui/Editor/Styles";

        public static readonly string[] GlobalStylesheets = {
            $"{BaseStylesPath}/Global/variables.uss",
            $"{BaseStylesPath}/Global/helpers.uss"
        };

        public static readonly string[] ElementStylesheets = {
            $"{BaseStylesPath}/Elements/label.uss",
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
        
        public Foldout Foldout(string fieldName, string fieldBinding, EventCallback<bool> onChange = null) {
            return new Foldout(fieldName, fieldBinding, onChange, root);
        }
        
        public Button Button(string name, Action onClick) {
            return new Button(name, onClick, root);
        }
        
        public Field<TFieldType> Field<TFieldType>(string fieldName, string fieldBinding, EventCallback<TFieldType> onChange = null) {
            return new Field<TFieldType>(fieldName, fieldBinding, onChange, root);
        }

        public Slider Slider(string name, string binding, float lowValue, float highValue, EventCallback<float> onChange = null) {
            return new Slider(name, binding, lowValue, highValue, onChange, root);
        }
        
        public Curve Curve(string fieldName, string fieldBinding, EventCallback<AnimationCurve> onChange = null) {
            return new Curve(fieldName, fieldBinding, onChange, root);
        }
        
        public Enum<TEnumType> Enum<TEnumType>(string name, string binding, TEnumType defaultValue, EventCallback<TEnumType> onChange = null) where TEnumType : Enum {
            return new Enum<TEnumType>(name, binding, defaultValue, onChange, root);
        }
        
        public LayerMask LayerMask(string name, string binding, EventCallback<int> onChange = null) {
            return new LayerMask(name, binding, onChange, root);
        }

        public ObjectField<TObjectType> ObjectField<TObjectType>(string name, string binding, EventCallback<TObjectType> onChange = null) where TObjectType : Object {
            return new ObjectField<TObjectType>(name, binding, onChange, root);
        }

    }
    
}
