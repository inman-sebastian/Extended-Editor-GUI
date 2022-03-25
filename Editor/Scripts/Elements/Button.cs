using System;
using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public class Button : Element<UnityEngine.UIElements.Button> {
        
        public bool enabled {
            get => element.enabledSelf;
            set => element.SetEnabled(value);
        }
        
        public Button(string name, Action onClick, VisualElement template) : base(name, template) {
            element?.RegisterCallback<ClickEvent>(_ => onClick());
        }

    }
    
}
