using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace DefaultNamespace
{
    public class SkillsElement: MonoBehaviour
    {
        [SerializeField]
        private AtributesSkills atributesSkills;
        [SerializeField]
        private AttributesElement attributesElement;
        
        public void OnHoverConstitution()
        {
            ToggleXpPrices(true);
            atributesSkills.Constitution += 1;
            attributesElement.SetAttributesView(atributesSkills.GetConstitutionAttributes(), true);
            atributesSkills.Constitution -= 1;
        }
        
        public void OnHoverStrength()
        {
            atributesSkills.Strength += 1;
            attributesElement.SetAttributesView(atributesSkills.GetStrengthAttributes(), true);
            atributesSkills.Strength -= 1;
        }
        public void OnHoverDexterity()
        {
            atributesSkills.Dexterity += 1;
            attributesElement.SetAttributesView(atributesSkills.GetDexterityAttributes(), true);
            atributesSkills.Dexterity -= 1;
        }
        public void OnHoverLuck()
        {
            atributesSkills.Luck += 1;
            attributesElement.SetAttributesView(atributesSkills.GetLuckAttributes(), true);
            atributesSkills.Luck -= 1;
        }
        
        public void OnHoverExitConstitution()
        {
            ToggleXpPrices(false);
            attributesElement.SetAttributesView(atributesSkills.GetConstitutionAttributes(), false);
        }
        public void OnHoverExitStrength()
        {
            attributesElement.SetAttributesView(atributesSkills.GetStrengthAttributes(), false);
        }
        public void OnHoverExitDexterity()
        {
            attributesElement.SetAttributesView(atributesSkills.GetDexterityAttributes(), false);
        }
        public void OnHoverExitLuck()
        {
            attributesElement.SetAttributesView(atributesSkills.GetLuckAttributes(), false);
        }
        
        public void OnClickConstitution()
        {
            if (atributesSkills.IncreaseConstitution())
            {
                RefreshValues();
                ToggleXpPrices(true);
                OnHoverConstitution();
            }
        }
        public void OnClickStrength()
        {
            if (atributesSkills.IncreaseStrength())
            {
                RefreshValues();
                ToggleXpPrices(true);
                OnHoverStrength();
            }
        }
        public void OnClickDexterity()
        {
            if (atributesSkills.IncreaseDexterity())
            {
                RefreshValues();
                ToggleXpPrices(true);
                OnHoverDexterity();
            }
        }
        public void OnClickLuck()
        {
            if (atributesSkills.IncreaseLuck())
            {
                RefreshValues();
                ToggleXpPrices(true);
                OnHoverLuck();
            }
        }

        void Start()
        {
            Debug.Log("SkillsElement Start");
            RefreshSkills();
            SetMainXpValue();
            ToggleXpPrices(false);
        }

        public void RefreshValues()
        {
            attributesElement.RefreshValues();
            RefreshSkills();
            SetMainXpValue();
        }

        private void RefreshSkills()
        {
            GameObject[] skillValueElements = GameObject.FindGameObjectsWithTag("SkillValue");
            for (var index = 0; index < skillValueElements.Length; index++)
            {
                var element = skillValueElements[index];
                int skillValue = (int) GetValue(element.transform.parent.name);
                element.GetComponent<TextMeshProUGUI>().text = skillValue.ToString();
            }
        }
        
        private double GetValue(string name)
        {
            double value = Double.Parse((atributesSkills.GetType().GetProperty(name)?.GetValue(atributesSkills, null)!).ToString());
            return value > 0 ? value : 0;
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
        private void SetMainXpValue()
        {
            GameObject xpElement= GameObject.Find("Xp");
            TextMeshProUGUI xpText = xpElement.transform.Find("Value").GetComponent<TextMeshProUGUI>();
            xpText.text = atributesSkills.Xp.ToString();
        }
    }
}