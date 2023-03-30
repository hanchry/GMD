using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AtributesSkills : MonoBehaviour
{
    
    private float HpValue = 1200.0f;
    private float HeavyAttackValue = 12.0f;
    private float HeavyDefenseValue = 12.0f;
    private float BlockValue = 5.0f;

    public void OnHoverTrigger(string name)
    {
        switch (name)
        {
            case "Constitution":
                this.HoverConstitution();
                break;
            case "Strength":
                this.HoverStrength();
                break;
        }
    }
    
    public void OnHoverExitTrigger(string name)
    {
        switch (name)
        {
            case "Constitution":
                this.HoverExitConstitution();
                break;
            case "Strength":
                this.HoverExitStrength();
                break;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private string Hp = "HpValue";
    private string Stamina = "StaminaValue";
    
    private string HeavyAttack = "HeavyAttackValue";
    private string HeavyDefense = "HeavyDefenseValue";
    
    private string LightAttack = "LightAttackValue";
    private string LightDefense = "LightDefenseValue";
    
    private string Dodge = "DodgeValue";
    private string Block = "BlockValue";
    
    private void HoverConstitution()
    {
        showChange(Hp, (int)HpValue,  1, "");
    }
    private void HoverStrength()
    {
        showChange(Hp, HpValue,  0.1f, "");
        showChange(HeavyAttack, HeavyAttackValue,  1, "");
        showChange(HeavyDefense, HeavyDefenseValue,  1, "");
        showChange(Block, BlockValue,  1, "%");
    }
    
    
    
    
    private void HoverExitConstitution()
    {
        showChange(Hp, HpValue,  0, "");
    }
    private void HoverExitStrength()
    {
        showChange(Hp, HpValue,  0, "");
        showChange(HeavyAttack, HeavyAttackValue,  0, "");
        showChange(HeavyDefense, HeavyDefenseValue,  0, "");
        showChange(Block, BlockValue,  0, "%");
    }

    private void showChange(string name, float originalValue, float value, string symbol)
    {
        GameObject changeObject = GameObject.Find(name);
        Color showColor;

        if (value > 0)
        {
            showColor = new Color(0.3490196f, 0.6392157f, 0.372549f);
        }
        else
        {
            showColor = Color.white;
        }
        
        changeObject.GetComponent<TextMeshProUGUI>().color = showColor;
        changeObject.GetComponent<TextMeshProUGUI>().text = (originalValue + value).ToString() + symbol;
    }
}
