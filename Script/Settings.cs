using UnityEngine;

namespace Inheo.GenerateNamaspace
{
    public class Settings : ScriptableObject
    {
        [SerializeField]
        [Tooltip("Don't include these folders when generate namespace.")]
        private string[] _dontIncludeFoldersInNamespace = new string[]
        {
            "Scripts",
            "Script",
            "CodeBase"
        };

        public string[] DontIncludeFoldersInNamespace => _dontIncludeFoldersInNamespace;
    }
}