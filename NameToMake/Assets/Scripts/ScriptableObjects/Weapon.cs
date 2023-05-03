using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
    public class Weapon :ScriptableObject
    {
        public string weaponName;
        // public WeaponRarity rarity;
        public WeaponType type;
        public int minDamage;
        public int maxDamage;
        public int criticalDamage;
    }
}