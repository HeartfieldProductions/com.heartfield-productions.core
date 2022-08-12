using UnityEngine;

namespace Heartfield
{
    public sealed class DisplayNameAttribute : PropertyAttribute
    {
        string _label;

        public string GetLabel => _label;

        public DisplayNameAttribute(string label)
        {
            _label = label;
        }
    }
}