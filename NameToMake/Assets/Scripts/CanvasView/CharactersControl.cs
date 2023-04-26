using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        private void Start()
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject playerButton = Instantiate(Resources.Load("Prefabs/PlayerButton")) as GameObject;
                GameObject addCharacterButton = Instantiate(Resources.Load("Prefabs/AddCharacterButton")) as GameObject;
                GameObject placeHolder = GameObject.Find("PlaceHolder1");

                if (playerButton != null)
                {
                    playerButton.transform.SetParent(placeHolder.transform, false);
                    playerButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                }


                // if (i <= _characters.GetCharactersNames().Length - 1)
                // {
                //     playerButton.transform.SetParent(GameObject.Find("PlaceHolder" + i).transform, false);
                //     playerButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                // }
                // else
                // {
                //     addCharacterButton.transform.SetParent(GameObject.Find("PlaceHolder" + i).transform, false);
                //     addCharacterButton.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                // }

            }
        }
    }
}