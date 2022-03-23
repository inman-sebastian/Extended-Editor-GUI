using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public class Field<T> : Element<BaseField<T>> {

        public T value;
        
        public Field(string name, VisualElement template) : base(name, template) {
            element = template.Q<BaseField<T>>(name);
        }
        
        public Field(string name, T defaultValue, VisualElement template) : base(name, template) {
            element = template.Q<BaseField<T>>(name);
            element.value = value = defaultValue;
        }

        public void OnChange(EventCallback<Field<T>> changeEvent) {
            element?.RegisterCallback<ChangeEvent<T>>(@event => {
                value = @event.newValue;
                changeEvent(this);
            });
        }
        
        public void SetValue(T newValue) {
            element.value = value = newValue;
        }

        public void ClampValue(T minValue, T maxValue) {
            if (float.Parse(element.value.ToString()) < float.Parse(minValue.ToString())) {
                element.value = minValue;
            }
            if (float.Parse(element.value.ToString()) > float.Parse(maxValue.ToString())) {
                element.value = maxValue;
            }
        }
        
    }
    
}
