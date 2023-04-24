using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class OptionsControl:MonoBehaviour
    {
        public void OnClickBack()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}