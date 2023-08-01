using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class MapInspectorInstaler : MonoInstaller
    {
        [SerializeField] private Toggle[] m_modifiersToggle;

        [SerializeField] private TMP_Text[] m_modifiers;

        public override void InstallBindings()
        {
            Container.Bind<Toggle[]>().FromInstance(m_modifiersToggle);
            Container.Bind<TMP_Text[]>().WithId("ModifiersText").FromInstance(m_modifiers);
        }
    }
}