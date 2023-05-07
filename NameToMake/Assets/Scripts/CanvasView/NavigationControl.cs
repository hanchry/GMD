using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationControl : MonoBehaviour
{
    
    public void OnInventoryClick()
    {
        if(CurrentScene() == "Inventory")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("Inventory");
        }
    }
    public void OnSkillsAttributesClick()
    {
        if (CurrentScene() == "AttributesSkills")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("AttributesSkills");
        }
    }
    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    
    void Start()
    {
        GameObject obj = GameObject.Find("PlayerName");
        obj.GetComponent<TextMeshProUGUI>().text = Characters.Instance.GetCurrentCharacterName();
    }
    

    private string CurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
    
}