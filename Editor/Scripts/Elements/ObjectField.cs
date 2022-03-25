using UnityEngine;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class ObjectField<T> : Element<UnityEditor.UIElements.ObjectField> where T : Object {

        public ObjectField(string name, EventCallback<T> onChange, VisualElement template) : base(name, template) {

            element.objectType = typeof(T);
            element.allowSceneObjects = true;
            element.bindingPath = name;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<Object>>(_ => onChange?.Invoke(element.value as T));   
            }

        }

    }
    
}
