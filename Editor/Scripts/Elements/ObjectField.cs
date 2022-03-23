using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public class ObjectField<T> : Element<UnityEditor.UIElements.ObjectField> where T : UnityEngine.Object {

        public T value;
        
        public ObjectField(string name, VisualElement template) : base(name, template) {
            element = template.Q<UnityEditor.UIElements.ObjectField>(name);
            element.objectType = typeof(T);
        }
        
        public ObjectField(string name, T defaultValue, VisualElement template) : base(name, template) {
            element = template.Q<UnityEditor.UIElements.ObjectField>(name);
            element.objectType = typeof(T);
            element.value = value = defaultValue;
        }

        public void OnChange(EventCallback<ObjectField<T>> changeEvent) {
            element?.RegisterCallback<ChangeEvent<T>>(@event => {
                value = @event.newValue;
                changeEvent(this);
            });
        }

    }
    
}
