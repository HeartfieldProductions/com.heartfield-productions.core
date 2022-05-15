using UnityEngine;

namespace Heartfield
{
    public class ShowOnlyAttribute : PropertyAttribute
    {
        public readonly float min;
        public readonly float max;
        public bool setMinMax;

        public readonly float offset;

        public ShowOnlyAttribute(float min, float max, float offset = 0)
        {
            this.min = min;
            this.max = max;
            this.offset = offset;

            setMinMax = true;
        }

        public ShowOnlyAttribute(float offset = 0)
        {
            this.offset = offset;
            setMinMax = false;
        }
    }
}