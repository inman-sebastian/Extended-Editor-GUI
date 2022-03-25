using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class LayerMask : Element<LayerMaskField> {

        public LayerMask(string name, EventCallback<int> onChange, VisualElement template) : base(name, template) {

            element.bindingPath = name;

            if (onChange != null) {
                element?.RegisterCallback<ChangeEvent<LayerMask>>(_ => onChange?.Invoke(element.value));   
            }

        }

    }
    
}
