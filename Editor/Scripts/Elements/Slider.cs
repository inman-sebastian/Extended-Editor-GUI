using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct SliderAttributes {
        public float defaultValue;
        public float lowValue;
        public float highValue;
        public EventCallback<Slider> beforeChange;
        public EventCallback<Slider> afterChange;
    }
    
    public class Slider : Element<UnityEngine.UIElements.Slider> {

        public float value;

        public Slider(string name, SliderAttributes attributes, VisualElement template) : base(name, template) {

            element.value = value = attributes.defaultValue;
            element.lowValue = attributes.lowValue;
            element.highValue = attributes.highValue;
            
            element.RegisterCallback<ChangeEvent<float>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
