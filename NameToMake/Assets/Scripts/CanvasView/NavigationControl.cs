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

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("PlayerName");
        obj.GetComponent<TextMeshProUGUI>().text = Characters.Instance.GetCurrentCharacterName();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private string CurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
    
}