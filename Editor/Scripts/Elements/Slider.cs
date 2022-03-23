using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct SliderAttributes<T> {
        public float lowValue;
        public float highValue;
        public EventCallback<Slider<T>> onChange;
    }
    
    public class Slider<T> : Element<UnityEngine.UIElements.Slider> {

        public float value;
        
        public Slider(T reference, SliderAttributes<T> attributes, VisualElement template) : base(reference.ToString(), template) {
            
            Debug.Log(reference.ToString());
            
            /*element = template.Q<UnityEngine.UIElements.Slider>(name);

            if (element == null) return;
            
            element.lowValue = attributes.lowValue;
            element.highValue = attributes.highValue;*/
            
            /*element.RegisterCallback<ChangeEvent<float>>(@event => {
                attributes.reference = value = @event.newValue;
                attributes.onChange?.Invoke(this);
            });*/

        }

    }
    
}
