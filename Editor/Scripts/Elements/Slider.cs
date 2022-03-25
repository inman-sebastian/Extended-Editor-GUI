using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Slider : Element<UnityEngine.UIElements.Slider> {

        public Slider(string name, float lowValue, float highValue, EventCallback<float> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = name;
            element.lowValue = lowValue;
            element.highValue = highValue;
            
            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<float>>(_ => onChange?.Invoke(element.value));   
            }

        }

    }
    
}
