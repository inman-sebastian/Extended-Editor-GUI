using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct SliderAttributes<T> {
        public string name;
        public float defaultValue;
        public float lowValue;
        public float highValue;
    }
    
    public class Slider<T> : Element<UnityEngine.UIElements.Slider> {

        public float value;
        
        public Slider(SliderAttributes<T> attributes, VisualElement template) : base(attributes.name, template) {
            element = template.Q<UnityEngine.UIElements.Slider>(name);
            element.lowValue = attributes.lowValue;
            element.highValue = attributes.highValue;
            element.value = attributes.defaultValue;
        }

        public void OnChange(EventCallback<Slider<T>> changeEvent) {
            element?.RegisterCallback<ChangeEvent<float>>(@event => {
                value = @event.newValue;
                changeEvent(this);
            });
        }

    }
    
}
