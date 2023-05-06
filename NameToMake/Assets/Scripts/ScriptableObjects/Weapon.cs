using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
    public class Weapon :ScriptableObject
    {
        public string weaponName;
        public WeaponType type;
        public int minDamage;
        public int maxDamage;
        public int criticalDamage;
        public string prefabName;
    }
}