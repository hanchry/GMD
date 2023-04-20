using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class AtributesSkills:MonoBehaviour
    {

        [SerializeField] private Character character;
        private List<String> ConstiutionAttributes;
        private List<String> StrengthAttrubutes;
        private List<String> DexterityAttributes;
        private List<String> LuckAttributes;
        

        void Start()
        {
            ConstiutionAttributes = new List<string>(){"Hp"};
            StrengthAttrubutes = new List<string>(){"HeavyAttack", "HeavyDefense","Block"};
            DexterityAttributes = new List<string>(){"Stamina", "LightAttack", "LightDefense", "Dodge"};
            LuckAttributes = new List<string>(){"Dodge", "Block"};
        }
        
        public int Constitution
        {
            get => character.skills.constitution;
            set => character.skills.constitution = value;
        }
        public int Strength
        {
            get => character.skills.strength;
            set => character.skills.strength = value;
        }
        public int Dexterity
        {
            get => character.skills.dexterity;
            set => character.skills.dexterity = value;
        }
        public int Luck
        {
            get => character.skills.luck;
            set => character.skills.luck = value;
        }
        
        public bool IncreaseConstitution()
        {
            if (Xp >= ConstitutionXpPrice)
            {
                Xp -= ConstitutionXpPrice;
                Constitution += 1;
                return true;
            }
            return false;
        }
        public bool IncreaseStrength()
        {
            if (Xp >= StrengthXpPrice)
            {
                Xp -= StrengthXpPrice;
                Strength += 1;
                return true;
            }
            return false;
        }
        public bool IncreaseDexterity()
        {
            if (Xp >= DexterityXpPrice)
            {
                Xp -= DexterityXpPrice;
                Dexterity += 1;
                return true;
            }
            return false;
        }
        public bool IncreaseLuck()
        {
            if (Xp >= LuckXpPrice)
            {
                Xp -= LuckXpPrice;
                Luck += 1;
                return true;
            }
            return false;
        }
        
        public int Xp
        {
            get => character.xp;
            set => character.xp = value;
        }
        public int ConstitutionXpPrice
        {
            get => (Constitution * 5) - (Constitution/2);
        }
        public int StrengthXpPrice
        {
            get => (Strength * 5) - (Strength/2);
        }
        public int DexterityXpPrice
        {
            get => (Dexterity * 5) - (Dexterity/2);
        }
        public int LuckXpPrice
        {
            get => (Luck * 5) - (Luck/2);
        }



        public double Hp
        {
            get => Constitution * 10;
        }
        public double Stamina
        {
            get => Dexterity * 10;
        }
        public double HeavyAttack
        {
            get => Strength;
        }
        public double HeavyDefense
        {
            get => Strength;
        }
        public double LightAttack
        {
            get => Dexterity;
        }
        public double LightDefense
        {
            get => Dexterity;
        }
        public double Dodge
        {
            get => Dexterity * 0.5 + Luck ;
        }
        public double Block
        {
            get => Strength * 0.5 + Luck;
        }
        
        public IList<String> GetConstitutionAttributes()
        {
            return ConstiutionAttributes;
        }
        public IList<String> GetStrengthAttributes()
        {
            return StrengthAttrubutes;
        }
        public IList<String> GetDexterityAttributes()
        {
            return DexterityAttributes;
        }
        public IList<String> GetLuckAttributes()
        {
            return LuckAttributes;
        }
        
    }
}