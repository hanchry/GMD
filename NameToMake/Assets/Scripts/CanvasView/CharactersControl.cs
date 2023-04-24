using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class CharactersControl:MonoBehaviour
    {
        public void OnClickBack()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}