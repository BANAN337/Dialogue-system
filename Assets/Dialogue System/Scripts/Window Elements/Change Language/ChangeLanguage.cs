using System.Linq;
using Dialogue_System.Scripts.Node_Utility;
using UnityEngine.UIElements;

namespace Dialogue_System.Scripts.Window_Elements.Change_Language
{
    public sealed class ChangeLanguage: WindowElement
    {
        public override string ElementName { get; } = "ChangeLanguage";
        public PopupField<string> Popup { get; private set; } = new();

        private const string Title = "Change Language";
        
        private ChangeLanguageHandler _changeLanguageHandler;

        public ChangeLanguage(VisualElement elementContainer, ChangeLanguageHandler changeLanguageHandler) : base(elementContainer)
        {
            _changeLanguageHandler = changeLanguageHandler;
            ConfigureElement();
            elementContainer.Add(Popup);
        }

        protected override void ConfigureElement()
        {
            Popup.name = ElementName;
            
            Popup.label = Title;
            
            Popup.RegisterValueChangedCallback((evt) =>
            {
                
            });

            Popup.choices = _changeLanguageHandler.Choices;
            
            Popup.value = Popup.choices[0];
        }
    }
}
