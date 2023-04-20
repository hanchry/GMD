using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace DefaultNamespace
{
    public class AttributesSkillsView : MonoBehaviour
    {
        public AtributesSkills atributesSkills;

        private Dictionary<String, String> elemetIdsMap;


        public void OnHoverConstitution()
        {
            ToggleXpPrices(true);
            atributesSkills.Constitution += 1;
            SetAttributesView(atributesSkills.GetConstitutionAttributes(), true);
            atributesSkills.Constitution -= 1;
        }
        public void OnHoverStrength()
        {
            ToggleXpPrices(true);
            atributesSkills.Strength += 1;
            SetAttributesView(atributesSkills.GetStrengthAttributes(), true);
            atributesSkills.Strength -= 1;
        }
        public void OnHoverDexterity()
        {
            ToggleXpPrices(true);
            atributesSkills.Dexterity += 1;
            SetAttributesView(atributesSkills.GetDexterityAttributes(), true);
            atributesSkills.Dexterity -= 1;
        }
        public void OnHoverLuck()
        {
            ToggleXpPrices(true);
            atributesSkills.Luck += 1;
            SetAttributesView(atributesSkills.GetLuckAttributes(), true);
            atributesSkills.Luck -= 1;
        }
        public void OnHoverExitConstitution()
        {
            ToggleXpPrices(false);
            SetAttributesView(atributesSkills.GetConstitutionAttributes(), false);
        }
        public void OnHoverExitStrength()
        {
            ToggleXpPrices(false);
            SetAttributesView(atributesSkills.GetStrengthAttributes(), false);
        }
        public void OnHoverExitDexterity()
        {
            ToggleXpPrices(false);
            SetAttributesView(atributesSkills.GetDexterityAttributes(), false);
        }
        public void OnHoverExitLuck()
        {
            ToggleXpPrices(false);
            SetAttributesView(atributesSkills.GetLuckAttributes(), false);
        }
        private void SetAttributesView(IList<String> attributes, bool isHover )
        {
            foreach (var attribute in attributes)
            {
                if (isHover)
                    SetUiIncreaseColor(elemetIdsMap[attribute], GetValue(attribute));
                else
                    SetUiBasicColor(elemetIdsMap[attribute], GetValue(attribute));
            }
        }
        
        
        public void OnClickConstitution()
        {
            if (atributesSkills.IncreaseConstitution())
            {
                SetUpView();
                ToggleXpPrices(true);
                OnHoverConstitution();
            }
        }
        public void OnClickStrength()
        {
            if (atributesSkills.IncreaseStrength())
            {
                SetUpView();
                ToggleXpPrices(true);
                OnHoverStrength();
            }
        }
        public void OnClickDexterity()
        {
            if (atributesSkills.IncreaseDexterity())
            {
                SetUpView();
                ToggleXpPrices(true);
                OnHoverDexterity();
            }
        }
        public void OnClickLuck()
        {
            if (atributesSkills.IncreaseLuck())
            {
                SetUpView();
                ToggleXpPrices(true);
                OnHoverLuck();
            }
        }

        public void StartView()
        {
            elemetIdsMap = new Dictionary<string, string>();
            elemetIdsMap.Add("Hp", "HpValue");
            elemetIdsMap.Add("Stamina", "StaminaValue");
            elemetIdsMap.Add("HeavyAttack", "HeavyAttackValue");
            elemetIdsMap.Add("HeavyDefense", "HeavyDefenseValue");
            elemetIdsMap.Add("LightAttack", "LightAttackValue");
            elemetIdsMap.Add("LightDefense", "LightDefenseValue");
            elemetIdsMap.Add("Dodge", "DodgeValue");
            elemetIdsMap.Add("Block", "BlockValue");


            ToggleXpPrices(false);
            SetUpView();
        }

        private void XpPrices()
        {
            GameObject[] xpElements = GameObject.FindGameObjectsWithTag("XpPrice");

            foreach (var element in xpElements)
            {
                TextMeshProUGUI xpText = element.transform.Find("Value").GetComponent<TextMeshProUGUI>();
                double skillValue = GetValue(element.transform.parent.name + "XpPrice");
                xpText.text = skillValue.ToString(CultureInfo.InvariantCulture);
                element.GetComponent<RectTransform>().sizeDelta = new Vector2(55 + (skillValue.ToString(CultureInfo.InvariantCulture).Length - 1) * 10, 35);
            }
        }
        private void ToggleXpPrices(bool show)
        {
            GameObject[] xpElements = GameObject.FindGameObjectsWithTag("XpPrice");
            if (show)
            {
                XpPrices();
            }

            foreach (var element in xpElements)
            {
                for (int i = 0; i < element.transform.childCount; i++)
                {
                    element.transform.GetChild(i).gameObject.SetActive(show);
                }

                element.GetComponent<Image>().enabled = show;
            }
        }
        private void SetSkillValues()
        {
            GameObject[] skillValueElements = GameObject.FindGameObjectsWithTag("SkillValue");
            foreach (var element in skillValueElements)
            {
                int skillValue = (int) GetValue(element.transform.parent.name);
                element.GetComponent<TextMeshProUGUI>().text = skillValue.ToString();
            }
        }

        private void SetMainXpValue()
        {
            GameObject xpElement= GameObject.Find("Xp");
            TextMeshProUGUI xpText = xpElement.transform.Find("Value").GetComponent<TextMeshProUGUI>();
            xpText.text = atributesSkills.Xp.ToString();
        }
        
        private void SetUpView()
        {
            foreach (var element in elemetIdsMap)
            {
                SetUiBasicColor(element.Value, GetValue(element.Key));
            }

            SetSkillValues();
            SetMainXpValue();
        }

        private double GetValue(string name)
        {
            double value = Double.Parse((atributesSkills.GetType().GetProperty(name)?.GetValue(atributesSkills, null)!).ToString());
            return value > 0 ? value : 0;
        }
        
        private void SetUiIncreaseColor(string name, double value)
        {
            Color green = new Color(0, 1, 0);
            GameObject.Find(name).GetComponent<TextMeshProUGUI>().color = green;
            SetUiValue(name, value);
        }

        private void SetUiBasicColor(string name, double value)
        {
            GameObject.Find(name).GetComponent<TextMeshProUGUI>().color = Color.white;
            SetUiValue(name, value);
        }

        private void SetUiValue(string name, double value)
        {
            string type = name.Contains("Dodge") || name.Contains("Block") || name.Contains("Defense") ? "%" : "";
            GameObject.Find(name).GetComponent<TextMeshProUGUI>().text = value.ToString() + type;
        }
    }
}