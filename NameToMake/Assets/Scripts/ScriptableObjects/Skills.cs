using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Skills", menuName = "Skills", order = 0)]
    public class Skills:ScriptableObject
    {
        public int constitution;
        public int strength;
        public int dexterity;
        public int luck;
    }
}