using UnityEngine;

namespace Objects.Objects
{
    [CreateAssetMenu(fileName = "NPC", menuName = "NPC")]
    public class NPC:ScriptableObject
    {
        public string npcName;
        public NpcType type;
        public int constitution;
        public int strength;
        public int dexterity;
        public int luck;
    }
}