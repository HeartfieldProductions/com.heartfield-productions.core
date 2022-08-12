namespace Heartfield
{
    public sealed class ShowOnlyRangeAttribute : ShowOnlyAttribute
    {
        internal readonly float min;
        internal readonly float max;

        public ShowOnlyRangeAttribute(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}