using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Curve : Element<CurveField> {

        public Curve(string name, string binding, EventCallback<AnimationCurve> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = binding;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<AnimationCurve>>(_ => onChange?.Invoke(element.value));   
            }
            
        }

    }
    
}
