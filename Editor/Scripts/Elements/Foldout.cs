using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class Foldout : Element<UnityEngine.UIElements.Foldout> {

        public Foldout(string name, EventCallback<bool> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = name;
            
            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<bool>>(_ => onChange?.Invoke(element.value));   
            }

        }

    }
    
}
