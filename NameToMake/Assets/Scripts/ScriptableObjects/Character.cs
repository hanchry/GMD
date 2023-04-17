using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class Character:ScriptableObject
    {
        public Skills skills;
        public new string name;
        public int xp;
    }
}