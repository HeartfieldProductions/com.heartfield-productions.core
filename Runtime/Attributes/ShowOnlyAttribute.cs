using UnityEngine;

namespace Heartfield
{
    public class ShowOnlyAttribute : PropertyAttribute
    {
        internal readonly float offset;

        public ShowOnlyAttribute() { }

        public ShowOnlyAttribute(float offset)
        {
            this.offset = offset;
        }
    }
}