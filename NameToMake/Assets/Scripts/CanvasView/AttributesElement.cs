using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;


namespace DefaultNamespace
{
    public class AttributesElement:MonoBehaviour
    {
        private Dictionary<String, String> elemetIdsMap;
        [SerializeField]
        private AtributesSkills atributesSkills;

        void Start()
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
            
            RefreshValues();
        }

        public void RefreshValues()
        {
            foreach (var element in elemetIdsMap)
            {
                SetUiBasicColor(element.Value, GetValue(element.Key));
            } 
        }

        public void SetAttributesView(IList<String> attributes, bool isHover )
        {
            foreach (var attribute in attributes)
            {
                if (isHover)
                    SetUiIncreaseColor(elemetIdsMap[attribute], GetValue(attribute));
                else
                    SetUiBasicColor(elemetIdsMap[attribute], GetValue(attribute));
            }
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