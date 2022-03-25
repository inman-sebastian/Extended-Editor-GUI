using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Curve : Element<CurveField> {

        public Curve(string name, EventCallback<AnimationCurve> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = name;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<AnimationCurve>>(_ => onChange?.Invoke(element.value));   
            }
            
        }

    }
    
}
