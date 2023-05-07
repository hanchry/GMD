using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CharacterCreationControl:MonoBehaviour
    {
        public void OnClickNext()
        {
            Destroy(GameObject.Find("Sound"));
            Characters.Instance.AddCharacterName(Characters.Instance.GetCurrentCharacterName());
            SceneManager.LoadScene("SampleScene");
        }
    }
}