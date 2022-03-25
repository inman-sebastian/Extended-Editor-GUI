using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Toggle : Element<UnityEngine.UIElements.Toggle> {

        public Toggle(string name, EventCallback<bool> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = name;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<bool>>(_ => onChange?.Invoke(element.value));   
            }
            
        }

    }
    
}
