using System;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class AtributesSkills:MonoBehaviour
    {
        
        private List<String> ConstiutionAttributes;
        private List<String> StrengthAttrubutes;
        private List<String> DexterityAttributes;
        private List<String> LuckAttributes;
        private string _characterName;


        void Start()
        {
            Debug.Log("AtributesSkills Start");
            ConstiutionAttributes = new List<string>(){"Hp"};
            StrengthAttrubutes = new List<string>(){"HeavyAttack", "HeavyDefense","Block"};
            DexterityAttributes = new List<string>(){"Stamina", "LightAttack", "LightDefense", "Dodge"};
            LuckAttributes = new List<string>(){"Dodge", "Block"};
            
            _characterName = Characters.Instance.GetCurrentCharacterName();
        }
        
        

        public int Constitution
        {
            get => PlayerPrefs.GetInt(_characterName+",Constitution", 1);
            set => PlayerPrefs.SetInt(_characterName+",Constitution", value);
        }

        public int Strength
        {
            get => PlayerPrefs.GetInt(_characterName+",Strength", 1);
            set => PlayerPrefs.SetInt(_characterName+",Strength", value);
        }
        public int Dexterity
        {
            get => PlayerPrefs.GetInt(_characterName+",Dexterity", 1);
            set => PlayerPrefs.SetInt(_characterName+",Dexterity", value);
        }
        public int Luck
        {
            get => PlayerPrefs.GetInt(_characterName+",Luck", 1);
            set => PlayerPrefs.SetInt(_characterName+",Luck", value);
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
            get => PlayerPrefs.GetInt("Xp", 800);
            
            set => PlayerPrefs.SetInt("Xp", value);
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
