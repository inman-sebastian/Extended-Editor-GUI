using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {
    
    public class Element<T> : VisualElement where T : VisualElement {
        
        public readonly T element;
        
        public bool isVisible {
            get => element.visible;
            set {
                if (value) {
                    RemoveClass("hidden");
                    AddClass("flex");
                } else {
                    RemoveClass("flex");
                    AddClass("hidden");
                }
                element.visible = value;
            }
        }
        
        public bool canFocus {
            get => element.focusable;
            set => element.focusable = value;
        }
        
        public bool isReadOnly {
            get => element.enabledSelf;
            set {
                element.SetEnabled(!value);
                canFocus = !value;
            }
        }

        public Element(string name, VisualElement template) {
            element = template.Q<T>(name);
        }
        
        protected void AddClass(string className) {
            element.AddToClassList(className);
        }
        
        protected void AddClass(string[] classNames) {
            foreach (var className in classNames) {
                element.AddToClassList(className);
            }
        }
        
        protected void RemoveClass(string className) {
            element.RemoveFromClassList(className);
        }
        
        protected void RemoveClass(string[] classNames) {
            foreach (var className in classNames) {
                element.RemoveFromClassList(className);
            }
        }

        protected void ToggleClass(string className) {
            if (element.ClassListContains(className)) {
                RemoveClass(className);
            } else {
                AddClass(className);
            }
        }
        
        protected void ToggleClass(string[] classNames) {
            foreach (var className in classNames) {
                if (element.ClassListContains(className)) {
                    RemoveClass(className);
                } else {
                    AddClass(className);
                }
            }
        }
        
    }
    
}
