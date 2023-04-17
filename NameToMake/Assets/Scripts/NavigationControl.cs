using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavigationControl : MonoBehaviour
{
    private string inventory = "BodyInventory";
    private string inventoryButtonText = "InventoryButtonText";
    private string  skillsAttributes = "BodyAttributesSkills";
    private string skillsAttributesButtonText = "SkillsButtonText";
    
    [SerializeField]
    private AttributesSkillsView _attributesSkillsView;
    
    private string viewActive = "none";
    
    public void OnInventoryClick()
    {
        if(viewActive != "none" && viewActive != "BodyInventory")
        {
            this.changeCheckView(viewActive);
        }
        this.changeCheckView("BodyInventory");
    }
    public void OnSkillsAttributesClick()
    {
        if(viewActive != "none" && viewActive != "BodySkills")
        {
            this.changeCheckView(viewActive);
        }
        this.changeCheckView("BodySkills");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void changeCheckView(string view)
    {
        switch (view)
        {
            case "BodyInventory":
                this.changeViewState(inventory, inventoryButtonText);
                break;
            case "BodySkills":
                this.changeViewState(skillsAttributes, skillsAttributesButtonText);
                _attributesSkillsView.StartView();
                break;
        }
    }

    private void changeViewState(string view, string buttonText)
    {
        if (!GameObject.Find(view).GetComponent<Image>().enabled)
        {
            GameObject.Find(buttonText).GetComponent<TextMeshProUGUI>().color = Color.white;
            viewActive = view;
        }
        else
        {
            viewActive = "none";
            Color color = new Color(0.624f,0.624f,0.624f, 1);
            GameObject.Find(buttonText).GetComponent<TextMeshProUGUI>().color = color;
        }
        GameObject.Find(view).GetComponent<Image>().enabled = !GameObject.Find(view).GetComponent<Image>().enabled;
        
        int childCount = GameObject.Find(view).transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject.Find(view).transform.GetChild(i).gameObject.SetActive(!GameObject.Find(view).transform.GetChild(i).gameObject.activeSelf);
        }
    }
}