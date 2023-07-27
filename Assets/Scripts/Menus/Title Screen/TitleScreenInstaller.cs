using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class TitleScreenInstaller : MonoInstaller
    {
        [SerializeField] private Image m_background;

        public override void InstallBindings()
        {
            Container.Bind<Image>().FromInstance(m_background);
        }
    }
}