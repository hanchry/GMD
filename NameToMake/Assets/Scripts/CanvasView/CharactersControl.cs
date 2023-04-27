using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharactersControl:MonoBehaviour
    {
        [SerializeField]
        private Characters _characters;
        public void OnClickBack()
        {
            SceneManager.LoadScene("Menu");
        }
        
        public void OnClickAddCharacter()
        {
            Debug.Log("Add character");
        }
        public void OnClickCharacter(string character)
        {
            Debug.Log("Character: " + character);
        }

        public void OnClickDelete()
        {
            Debug.Log("Delete");
        }

        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject placeHolder = GameObject.Find("PlaceHolder" + (i+1));

                if (i < _characters.GetCharactersNames().Length - 1)
                {
                    GameObject playerButton = Instantiate(Resources.Load("Prefabs/PlayerButton")) as GameObject;
                    playerButton.transform.SetParent(placeHolder.transform, false);
                    playerButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                    playerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _characters.GetCharactersNames()[i];
                }
                else 
                {
                    GameObject addCharacterButton = Instantiate(Resources.Load("Prefabs/AddCharacterButton")) as GameObject;
                    addCharacterButton.transform.SetParent(placeHolder.transform, false);
                    addCharacterButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                }
            }
            ToggleDeleteButton(false);
        }
        
        private void ToggleDeleteButton(bool show)
        {
            if (show)
            {
                GameObject.Find("DeleteButton").GetComponent<Image>().color = Color.white;
                GameObject.Find("DeleteButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            }
            else
            {
                Color color = new Color(255,255,255,0.2f);
                GameObject.Find("DeleteButton").GetComponent<Image>().color = color;
                GameObject.Find("DeleteButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
            }
        }
    }
}