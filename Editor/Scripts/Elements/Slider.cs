using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct SliderAttributes<T> {
        public float defaultValue;
        public float lowValue;
        public float highValue;
        public T reference;
        public EventCallback<Slider<T>> callback;
    }
    
    public class Slider<T> : Element<UnityEngine.UIElements.Slider> {

        public float value;
        
        public Slider(string name, SliderAttributes<T> attributes, VisualElement template) : base(name, template) {
            
            element = template.Q<UnityEngine.UIElements.Slider>(name);

            if (element == null) return;
            
            element.value = attributes.defaultValue;
            element.lowValue = attributes.lowValue;
            element.highValue = attributes.highValue;
            
            element.RegisterCallback<ChangeEvent<float>>(@event => {
                value = @event.newValue;
                attributes.callback?.Invoke(this);
            });

        }

    }
    
}
