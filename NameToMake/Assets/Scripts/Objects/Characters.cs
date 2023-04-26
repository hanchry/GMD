using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    private string[] _charactersNames;
    private string _currentCharacterName;
    
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
