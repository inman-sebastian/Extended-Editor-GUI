using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public struct EnumAttributes<T> where T : class, System.Enum {
        public T defaultValue;
        public EventCallback<Enum<T>> beforeChange;
        public EventCallback<Enum<T>> afterChange;
    }
    
    public class Enum<T> : Element<EnumField> where T : class, System.Enum {
        
        public T value;

        public Enum(string name, EnumAttributes<T> attributes, VisualElement template) : base(name, template) {

            element.Init(attributes.defaultValue);
            element.value = value = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<System.Enum>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue as T;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
