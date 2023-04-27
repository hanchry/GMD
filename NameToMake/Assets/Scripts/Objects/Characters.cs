using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private string[] _charactersNames;
    private string _currentCharacterName;

    private static Characters _instance;
    
    public static Characters Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Characters>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject();
                    _instance = singleton.AddComponent<Characters>();
                    singleton.name = typeof(Characters).ToString();
                    
                    // DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    // private void Awake()
    // {
    //     if (_instance == null)
    //     {
    //         _instance = this;
    //         // DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void Start()
    {
        AddTestCharacter();
    }

    private void AddTestCharacter()
    {
        if (GetCharactersNames().Length - 1 == 0)
        {
            AddCharacterName("TestyJoe");
        }
    }
    
    public string[] GetCharactersNames()
    {
        string characters = PlayerPrefs.GetString("Characters");
        _charactersNames = characters.Split(',');
        return _charactersNames;
    }
    public void AddCharacterName(string name)
    {
        string characters = PlayerPrefs.GetString("Characters");
        characters += name + ",";
        PlayerPrefs.SetString("Characters", characters);
    }
    public void RemoveCharacterName(string name)
    {
        string characters = PlayerPrefs.GetString("Characters");
        characters = characters.Replace(name + ",", "");
        PlayerPrefs.SetString("Characters", characters);
    }
    
    
    
    public string GetCurrentCharacterName()
    {
        _currentCharacterName = PlayerPrefs.GetString("CurrentCharacter");
        return _currentCharacterName;
    }
    public void SetCurrentCharacterName(string name)
    {
        PlayerPrefs.SetString("CurrentCharacter", name);
    }
}
