using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class TitleScreenController : MonoBehaviour
    {
        [SerializeField] private int m_backgroundIndex;
        private Image m_background;
        [SerializeField] private Sprite[] m_backgroundSprites;

        [Inject]
        private void Constructor(Image background)
        {
            m_background = background;
            m_background.sprite = m_backgroundSprites[m_backgroundIndex];
        }

        public void OnPlayButtonClick()
        {
            SceneManager.LoadScene(1);
        }

        public void OnExitButtonClick()
        {
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
        }

        public void OnCreditsButtonClick()
        {
            SceneManager.LoadScene(2);
        }
    }
}