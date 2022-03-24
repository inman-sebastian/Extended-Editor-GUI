using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct FieldAttributes<T> {
        public T defaultValue;
        public EventCallback<Field<T>> beforeChange;
        public EventCallback<Field<T>> afterChange;
    }
    
    public class Field<T> : Element<BaseField<T>> {

        public T value;

        public Field(string name, FieldAttributes<T> attributes, VisualElement template) : base(name, template) {

            element.value = value = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<T>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });
            
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
