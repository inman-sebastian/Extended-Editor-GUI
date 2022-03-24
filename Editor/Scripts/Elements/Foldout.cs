using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public struct FoldoutAttributes {
        public bool defaultValue;
        public EventCallback<Foldout> beforeChange;
        public EventCallback<Foldout> afterChange;
    }
    
    public class Foldout : Element<UnityEngine.UIElements.Foldout> {
        
        public bool expanded;

        public Foldout(string name, FoldoutAttributes attributes, VisualElement template) : base(name, template) {

            element.value = expanded = attributes.defaultValue;
            
            element?.RegisterCallback<ChangeEvent<bool>>(@event => {
                attributes.beforeChange?.Invoke(this);
                expanded = @event.newValue;
                attributes.afterChange?.Invoke(this);
            });

        }

    }
    
}
