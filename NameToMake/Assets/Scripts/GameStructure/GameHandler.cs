using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using PlayerControls;
using UnityEngine;
using Objects;
using PlayerControls.PlayerControl;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private HealthSystem _healthSystem;
    [SerializeField]
    private HealthCanvas _playerHealthCanvas;
    private AtributesSkills _attributeSkills;

    private Button DamageButton;
    private Button HealButton;
    
    // Start is called before the first frame update
    void Start()
    {
        //_attributeSkills get the max hp from here
        // _attributeSkills.Hp
        _healthSystem = new HealthSystem(40);
        
        //_playerHealthCanvas.Setup(_healthSystem);
        
        // DamageButton = GameObject.Find("Damage").GetComponent<Button>();
        // HealButton = GameObject.Find("Heal").GetComponent<Button>();
        
        // DamageButton.onClick.AddListener(() =>
        // {
        //     _healthSystem.Damage(10);
        //     Debug.Log("damage clicked: "+_healthSystem.GetHealth());
        // });
        // HealButton.onClick.AddListener(() =>
        // {
        //     _healthSystem.Heal(5);
        //     Debug.Log("heal clicked: " +_healthSystem.GetHealth());
        // });
    }

    // Update is called once per frame
    void Update()
    {
        // DamageButton.onClick.AddListener(() =>
        // {
        //    _healthSystem.Damage(10);
        // });
        // DamageButton.onClick.AddListener(() =>
        // {
        //     _healthSystem.Heal(5);
        // });
    }

   
}
