using UnityEngine;

namespace Heartfield.Protection.Test
{
    public sealed class AntiCheatTest : MonoBehaviour
    {
        public float health;
        public int inventoryCapacity;
        public bool wearArmor;

        public AntiCheat antiCheat = new AntiCheat();
    }
}