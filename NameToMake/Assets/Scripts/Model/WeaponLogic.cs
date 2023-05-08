using UnityEngine;

namespace Objects
{
    public class WeaponLogic:MonoBehaviour
    {
        [SerializeField]
        private Weapon _weapon;
        
        
        public int MinDamage => _weapon.minDamage;
        public int MaxDamage => _weapon.maxDamage;
        public int AvrageDamage => (_weapon.minDamage + _weapon.maxDamage) / 2;
        public int CriticalDamage => _weapon.criticalDamage;
        public string WeaponName => _weapon.weaponName;
        public WeaponType WeaponType => _weapon.type;
        public string PrefabName => _weapon.prefabName;
        
    }
}