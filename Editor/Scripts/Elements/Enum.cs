using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Enum<T> : Element<EnumField> where T : System.Enum {
        
        public T value;

        public Enum(string name, string binding, T defaultValue, EventCallback<T> onChange, VisualElement template) : base(name, template) {

            element.Init(defaultValue);
            element.bindingPath = binding;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<System.Enum>>(_ => onChange?.Invoke( element.value is T @enum ? @enum : default));   
            }

        }

    }
    
}
