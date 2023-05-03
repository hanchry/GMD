using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CharacterCreationControl:MonoBehaviour
    {
        public void OnClickNext()
        {
            Characters.Instance.AddCharacterName(Characters.Instance.GetCurrentCharacterName());
            SceneManager.LoadScene("SampleScene");
        }
    }
}