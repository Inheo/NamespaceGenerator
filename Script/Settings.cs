using UnityEngine;

namespace Inheo.GenerateNamaspace
{
    // [CreateAssetMenu(menuName = "Configs/Settings", fileName = "Settings")]
    public class Settings : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Don't include these folders when generate namespace.")]
        private string[] _dontIncludeFolders = new string[]
        {
            "Scripts",
            "Script",
            "CodeBase"
        };

        public string[] DontIncludeFolders => _dontIncludeFolders;
    }
}