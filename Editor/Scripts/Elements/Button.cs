using System;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public class Button : Element<UnityEngine.UIElements.Button> {
        
        public bool enabled {
            get => element.enabledSelf;
            set => element.SetEnabled(value);
        }
        
        public Button(string name, VisualElement template) : base(name, template) {
            element = template.Q<UnityEngine.UIElements.Button>(name);
        }
        
        public void OnClick(Action<Button> clickEvent) {
            element?.RegisterCallback<ClickEvent>(@event => clickEvent(this));
        }
        
    }
    
}
