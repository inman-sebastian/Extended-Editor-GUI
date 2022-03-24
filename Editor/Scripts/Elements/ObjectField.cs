using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public struct ObjectAttributes<T> where T : Object {
        public T defaultValue;
        public EventCallback<ObjectField<T>> beforeChange;
        public EventCallback<ObjectField<T>> afterChange;
    }
    
    public class ObjectField<T> : Element<UnityEditor.UIElements.ObjectField> where T : Object {

        public T value;
        
        public ObjectField(string name, ObjectAttributes<T> attributes, VisualElement template) : base(name, template) {

            element.objectType = typeof(T);
            element.allowSceneObjects = true;
            element.value = value = attributes.defaultValue;

            element?.RegisterCallback<ChangeEvent<Object>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue as T;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
