using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class TitleScreenInstaller : MonoInstaller
    {
        [SerializeField] TitleScreen m_titleScreen;
        [SerializeField] Image m_background;

        public override void InstallBindings()
        {
            m_titleScreen = GetComponent<TitleScreen>();
            Container.Bind<Image>().FromInstance(m_background);
            Container.Bind<TitleScreen>().FromInstance(m_titleScreen);
        }
    }
}