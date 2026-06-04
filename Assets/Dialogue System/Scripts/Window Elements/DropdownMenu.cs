using System;
using UnityEditor.Toolbars;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Window_Elements
{
    public class DropdownMenu
    {
        private ToolbarMenu _toolbarMenu;
        
        public ToolbarMenu CreateToolbarMenu(string name = "Toolbar Menu", params Action<DropdownMenuAction>[] actions)
        {
            _toolbarMenu = new ToolbarMenu
            {
                text = name
            };

            foreach (var action in actions)
            {
                
            }

            return _toolbarMenu;
        }
    }
}
