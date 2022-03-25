using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Field<T> : Element<BaseField<T>> {

        public Field(string name, string binding, EventCallback<T> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = binding;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<T>>(_ => onChange?.Invoke(element.value));   
            }
            
        }

    }
    
}
