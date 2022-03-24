using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public struct EnumAttributes<T> where T : System.Enum {
        public T defaultValue;
        public EventCallback<Enum<T>> beforeChange;
        public EventCallback<Enum<T>> afterChange;
    }
    
    public class Enum<T> : Element<EnumField> where T : System.Enum {
        
        public T value;

        public Enum(string name, EnumAttributes<T> attributes, VisualElement template) : base(name, template) {

            element.value = value = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<T>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
