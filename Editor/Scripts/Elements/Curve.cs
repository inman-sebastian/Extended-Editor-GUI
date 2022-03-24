using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct CurveAttributes {
        public AnimationCurve defaultValue;
        public EventCallback<Curve> beforeChange;
        public EventCallback<Curve> afterChange;
    }
    
    public class Curve : Element<CurveField> {

        public AnimationCurve value;

        public Curve(string name, CurveAttributes attributes, VisualElement template) : base(name, template) {

            element.value = value = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<AnimationCurve>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });
            
        }

    }
    
}
