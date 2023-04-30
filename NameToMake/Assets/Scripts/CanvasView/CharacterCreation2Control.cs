using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterCreation2Control : MonoBehaviour
    {

        private float _aniamtionFloat;
        private Material _material;

        public void OnClickCreate()
        {
            TextMeshProUGUI name = GameObject.Find("NameInput").GetComponent<TextMeshProUGUI>();
            Characters.Instance.SetCurrentCharacterName(name.text);
            SceneManager.LoadScene("CharacterCreate1");
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
            TextMeshProUGUI text = GameObject.Find("name").GetComponent<TextMeshProUGUI>();
            Material material = text.fontMaterial;
            material.SetFloat(ShaderUtilities.ID_FaceDilate, -1);
            _aniamtionFloat = -1;
            _material = material;
        }
        private void Animation()
        {
            _material.SetFloat(ShaderUtilities.ID_FaceDilate, _aniamtionFloat + (Time.deltaTime));
            _aniamtionFloat = _material.GetFloat(ShaderUtilities.ID_FaceDilate);
        }
    }
}