using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pinbattlers.Menus
{
    public class ExitAtlasConfirmBehaviour : MonoBehaviour
    {
        public void OnConfirmButtonClick()
        {
            SceneManager.LoadScene(0);
        }

        public void OnDeclineButtonClick()
        {
            Destroy(gameObject);
        }
    }
}