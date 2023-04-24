using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    private float _aniamtionFloat;
    private Material _material;
    
    
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Characters");
    }
    public void OnClickOptions()
    {
        SceneManager.LoadScene("Options");
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
   
    void Start()
    {
        BeginningAnimation();
        Animation();
    }
    
    void Update()
    {
        if (_aniamtionFloat < 0)
        {
            Animation();
        }
    }
    
    private void BeginningAnimation()
    {
        TextMeshProUGUI text = GameObject.Find("NameOfGame").GetComponent<TextMeshProUGUI>();
        Material material = text.fontMaterial;
        material.SetFloat(ShaderUtilities.ID_FaceDilate, -1);
        _aniamtionFloat = -1;
        _material = material;
    }

    private void Animation()
    {
        _material.SetFloat(ShaderUtilities.ID_FaceDilate, _aniamtionFloat + (Time.deltaTime/2));
         _aniamtionFloat = _material.GetFloat(ShaderUtilities.ID_FaceDilate);
    }
}