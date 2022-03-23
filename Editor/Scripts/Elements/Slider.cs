using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct SliderAttributes<T> {
        public float reference;
        public float lowValue;
        public float highValue;
        public EventCallback<Slider<T>> onChange;
    }
    
    public class Slider<T> : Element<UnityEngine.UIElements.Slider> {

        public float value;
        
        public Slider(string name, SliderAttributes<T> attributes, VisualElement template) : base(name, template) {
            
            element = template.Q<UnityEngine.UIElements.Slider>(name);

            if (element == null) return;
            
            element.value = attributes.reference;
            element.lowValue = attributes.lowValue;
            element.highValue = attributes.highValue;
            
            element.RegisterCallback<ChangeEvent<float>>(@event => {
                attributes.reference = value = @event.newValue;
                attributes.onChange?.Invoke(this);
            });

        }

    }
    
}
