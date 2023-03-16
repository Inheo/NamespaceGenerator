using UnityEditor;
using UnityEngine;

namespace Inheo.GenerateNamaspace
{
    internal class CreateMenuContextWindow : EditorWindow
    {
        private static CreateMenuContextWindow _window;
        private static Settings _settings;
        private static Editor _settingsEditor;

        [MenuItem("Window/Generator/Settings")]
        private static void ShowWindow()
        {
            _window = (CreateMenuContextWindow)GetWindow(typeof(CreateMenuContextWindow));
            _window.titleContent = new GUIContent("Namespace Generator Settings");
            _window.Show();
        }

        private void OnEnable()
        {
            _settings = Extensions.GetSettings();
            _settingsEditor = Editor.CreateEditor(_settings);
        }

        private void OnGUI()
        {
            if (_settings == null)
                this.Close();
            else
                _settingsEditor.OnInspectorGUI();
        }
    }
}