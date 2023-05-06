using System;
using UnityEditor;
using UnityEngine;

namespace Objects
{
    public class Items:MonoBehaviour
    {
        private string _characterName;
        
        private static Items _instance;
        
        public static Items Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Items>();
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<Items>();
                        singleton.name = typeof(Items).ToString();
                    
                        // DontDestroyOnLoad(singleton);
                    }
                }
                return _instance;
            }
        }
        public string[] GetInventoryItems()
        {
            return PlayerPrefs.GetString(_characterName+"InventoryItems").Split(',');
        }
        public void AddInventoryItem(string name)
        {
            string items = PlayerPrefs.GetString(_characterName+"InventoryItems");
            items += name + ",";
            PlayerPrefs.SetString(_characterName+"InventoryItems", items);
        }
        public void RemoveInventoryItem(string name)
        {
            string items = PlayerPrefs.GetString(_characterName+"InventoryItems");
            items = items.Replace(name + ",", "");
            PlayerPrefs.SetString(_characterName+"InventoryItems", items);
        }

        public string Weapon1
        {
            get => PlayerPrefs.GetString(_characterName+"EquiptWeapon1");
            set => PlayerPrefs.SetString(_characterName+"EquiptWeapon1", value);
        }

        private void Start()
        {
            _characterName = Characters.Instance.GetCurrentCharacterName();
            AddBeginningItems();
        }

        private void AddBeginningItems()
        {
            if(GetInventoryItems().Length- 1 == 0)
            {
                AddInventoryItem("SwordLight");
            }
        }
    }
}