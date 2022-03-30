using UnityEngine.UIElements;

namespace ExtendedEditorGUI.Elements {

    public class ListView : Element<UnityEngine.UIElements.ListView> {

        public ListView(string name, VisualElement template) : base(name, template) {

            element.bindingPath = name;
            
            // element.Add();

        }

    }
    
}
