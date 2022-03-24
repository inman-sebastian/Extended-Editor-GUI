using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public struct LayerMaskAttributes {
        public int defaultValue;
        public EventCallback<LayerMask> beforeChange;
        public EventCallback<LayerMask> afterChange;
    }
    
    public class LayerMask : Element<LayerMaskField> {
        
        public int value;

        public LayerMask(string name, LayerMaskAttributes attributes, VisualElement template) : base(name, template) {

            element.value = value = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<int>>(@event => {
                attributes.beforeChange?.Invoke(this);
                value = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
