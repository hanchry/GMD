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
    private string HeavyAttack = "HeavyAttackValue";
    private string HeavyDefense = "HeavyDefenseValue";
    private string Block = "BlockValue";
    
    private void HoverConstitution()
    {
        //make color 59A45F
        Color color = new Color(0.3490196f, 0.6392157f, 0.372549f);
        GameObject hpObject = GameObject.Find(Hp);
        hpObject.GetComponent<TextMeshProUGUI>().color = color;
        hpObject.GetComponent<TextMeshProUGUI>().text = (HpValue + 1).ToString();
    }
    private void HoverStrength()
    {
        //make color 59A45F
        Color color = new Color(0.3490196f, 0.6392157f, 0.372549f);
        GameObject hpObject = GameObject.Find(Hp);
        GameObject heavyAttackObject = GameObject.Find(HeavyAttack);
        GameObject heavyDefenseObject = GameObject.Find(HeavyDefense);
        GameObject blockObject = GameObject.Find(Block);
        
        hpObject.GetComponent<TextMeshProUGUI>().color = color;
        heavyAttackObject.GetComponent<TextMeshProUGUI>().color = color;
        heavyDefenseObject.GetComponent<TextMeshProUGUI>().color = color;
        blockObject.GetComponent<TextMeshProUGUI>().color = color;
        hpObject.GetComponent<TextMeshProUGUI>().text = (HpValue + 0.1).ToString();
        heavyAttackObject.GetComponent<TextMeshProUGUI>().text = (HeavyAttackValue + 1).ToString();
        heavyDefenseObject.GetComponent<TextMeshProUGUI>().text = (HeavyDefenseValue + 1).ToString();
        blockObject.GetComponent<TextMeshProUGUI>().text = (BlockValue + 0.1).ToString() + "%";
    }
    
    
    
    
    private void HoverExitConstitution()
    {
        GameObject hpObject = GameObject.Find(Hp);
        hpObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        hpObject.GetComponent<TextMeshProUGUI>().text = HpValue.ToString();
    }
    private void HoverExitStrength()
    {
        GameObject hpObject = GameObject.Find(Hp);
        GameObject heavyAttackObject = GameObject.Find(HeavyAttack);
        GameObject heavyDefenseObject = GameObject.Find(HeavyDefense);
        GameObject blockObject = GameObject.Find(Block);
        
        hpObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        heavyAttackObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        heavyDefenseObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        blockObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        hpObject.GetComponent<TextMeshProUGUI>().text = HpValue.ToString();
        heavyAttackObject.GetComponent<TextMeshProUGUI>().text = HeavyAttackValue.ToString();
        heavyDefenseObject.GetComponent<TextMeshProUGUI>().text = HeavyDefenseValue.ToString();
        blockObject.GetComponent<TextMeshProUGUI>().text = BlockValue.ToString() + "%";
    }
}
