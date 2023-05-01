using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharactersControl : MonoBehaviour
    {
        public void OnClickBack()
        {
            SceneManager.LoadScene("Menu");
        }

        public void OnClickAddCharacter()
        {
            SceneManager.LoadScene("CharacterCreate2");
        }

        public void OnClickCharacter(string character)
        {
            ToggleDeleteButton(true);
            Characters.Instance.SetCurrentCharacterName(character);
            Attributes();
            PlayButtonShow();
        }

        public void OnClickDelete()
        {
            DeleteCharacter();
        }

        public void OnClickPlay()
        {
            SceneManager.LoadScene("SampleScene");
        }

        private void Start()
        {
            SetupCharacterButtons();
            ToggleDeleteButton(false);
        }
        
        private void DeleteCharacter()
        {
            if (GameObject.Find("DeleteButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().color ==
                Color.white)
            {
                Characters.Instance.RemoveCharacterName(Characters.Instance.GetCurrentCharacterName());
                Characters.Instance.SetCurrentCharacterName("");
                SetupCharacterButtons();
                ToggleDeleteButton(false);
                Destroy(GameObject.Find("Atributes(Clone)"));
                Destroy(GameObject.Find("PlayButton(Clone)"));
            }
        }

        private void ToggleDeleteButton(bool show)
        {
            if (show)
            {
                GameObject.Find("DeleteButton").GetComponent<Image>().color = Color.white;
                GameObject.Find("DeleteButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().color =
                    Color.white;
            }
            else
            {
                Color color = new Color(255, 255, 255, 0.2f);
                GameObject.Find("DeleteButton").GetComponent<Image>().color = color;
                GameObject.Find("DeleteButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
            }
        }

        private void SetupCharacterButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject placeHolder = GameObject.Find("PlaceHolder" + (i + 1));

                if (i < Characters.Instance.GetCharactersNames().Length - 1)
                {
                    CharacterButton(placeHolder, i);
                }
                else
                {
                    AddCharacterButton(placeHolder);
                }
            }
        }

        private void CharacterButton(GameObject placeHolder, int i)
        {
            GameObject playerButton = Instantiate(Resources.Load("Prefabs/PlayerButton")) as GameObject;
            playerButton.transform.SetParent(placeHolder.transform, false);
            playerButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            playerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                Characters.Instance.GetCharactersNames()[i];

            Button button = playerButton.GetComponent<Button>();
            button.onClick.AddListener(delegate
            {
                OnClickCharacter(playerButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text);
            });
        }

        private void AddCharacterButton(GameObject placeHolder)
        {
            GameObject addCharacterButton = Instantiate(Resources.Load("Prefabs/AddCharacterButton")) as GameObject;
            addCharacterButton.transform.SetParent(placeHolder.transform, false);
            addCharacterButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            
            Button button = addCharacterButton.GetComponent<Button>();
            button.onClick.AddListener(delegate { OnClickAddCharacter(); });
        }

        private void Attributes()
        {
            if (GameObject.Find("Atributes(Clone)") != null)
                Destroy(GameObject.Find("Atributes(Clone)"));
            else
            {
                GameObject placeHolder = GameObject.Find("AttributesPlaceHolder");
                GameObject attributes = Instantiate(Resources.Load("Prefabs/Atributes")) as GameObject;
                attributes.transform.SetParent(placeHolder.transform, false);
                attributes.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            }
        }

        private void PlayButtonShow()
        {
            if (GameObject.Find("PlayButton(Clone)") != null)
                Destroy(GameObject.Find("PlayButton(Clone)"));
            else
            {
                GameObject placeHolder = GameObject.Find("PlayButtonPlaceHolder");
                GameObject playButton = Instantiate(Resources.Load("Prefabs/PlayButton")) as GameObject;
                playButton.transform.SetParent(placeHolder.transform, false);
                playButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                playButton.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlay(); });
            }
        }
    }
}