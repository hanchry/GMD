using System;
using Objects;
using UnityEngine;

namespace Model
{
    public class CombatValues : MonoBehaviour
    {
        [SerializeField]
        private AtributesSkills _atributesSkills;
    

        public Damage DamageGiven()
        {
            String weaponName = Items.Instance.GetWeapon1();
            Damage damage = new Damage();
        
            damage = BaseDamage(damage, weaponName);
        
            int critical = Critic() ? 2 : 1;
            damage.Value *= critical;

            return damage;
        }
    
        public Damage DamageReceived(Damage damage)
        {

            if (damage.Type == DamageType.Heavy && Block())
            {
                damage.Type = DamageType.Block;
                damage.Value = 0;
            }
            else if (Dodge())
            {
                damage.Type = DamageType.Dodge;
                damage.Value = 0;
            }
            return damage;
        }

        private void Start()
        {
            // Debug.Log(Items.Instance.Weapon1);
        
        }
    
        private Damage BaseDamage(Damage damage,String weaponName)
        {
            if (weaponName != "")
            {
                GameObject weaponPrefab = Resources.Load<GameObject>("Prefabs/UI/Items/" + weaponName);
                WeaponLogic weapon = weaponPrefab.GetComponent<WeaponLogic>();
                if (weapon.WeaponType == WeaponType.Heavy)
                {
                    damage.Value = DamageFromWeapon(weapon.MinDamage, weapon.MaxDamage) * _atributesSkills.Strength;
                    damage.Type = DamageType.Heavy;
                }
                else
                {  
                    damage.Value = DamageFromWeapon(weapon.MinDamage, weapon.MaxDamage) * _atributesSkills.Dexterity;
                    damage.Type = DamageType.Light;
                }
            }
            else
            {
                if (_atributesSkills.Strength > _atributesSkills.Dexterity)
                {
                    damage.Value = DamageFromWeapon(1, 5) * (_atributesSkills.Strength / 2);
                    damage.Type = DamageType.Heavy;
                }
                else
                {
                    damage.Value = DamageFromWeapon(1, 5) * (_atributesSkills.Dexterity / 2);
                    damage.Type = DamageType.Light;
                }
            }

            return damage;
        }

        private bool Block()
        {
            int chance = UnityEngine.Random.Range(0, 100);
            if (chance <= _atributesSkills.Block)
            {
                return true;
            }
            return false;
        }
        private bool Dodge()
        {
            int chance = UnityEngine.Random.Range(0, 100);
            if (chance <= _atributesSkills.Dodge)
            {
                return true;
            }
            return false;
        }
        private bool Critic()
        {
            int chance = UnityEngine.Random.Range(0, 100);
            if (chance <= _atributesSkills.Luck)
            {
                return true;
            }
            return false;
        }
        private int DamageFromWeapon(int minDamage, int maxDamage)
        {
            int damage = UnityEngine.Random.Range(minDamage, maxDamage);
            return damage;
        }
    
    }
}
