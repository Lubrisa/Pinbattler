using UnityEngine;
using Zenject;

namespace Pinbattlers.Menus
{
    public class OptionsMenuInstaller : MonoInstaller
    {
        [SerializeField] private RectTransform[] m_sessions;

        public override void InstallBindings()
        {
            Container.Bind<RectTransform[]>().FromInstance(m_sessions);
        }
    }
}