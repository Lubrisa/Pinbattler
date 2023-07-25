using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Pinbattlers.Menus
{
    public class OptionsMenuInstaller : MonoInstaller
    {
        [SerializeField] OptionsMenu m_optionsMenu;
        [SerializeField] GameObject[] m_sessions;

        [SerializeField] AudioMixer m_mixer;

        public override void InstallBindings()
        {
            m_optionsMenu = GetComponent<OptionsMenu>();
            Container.Bind<GameObject[]>().FromInstance(m_sessions);
            Container.Bind<AudioMixer>().FromInstance(m_mixer);
            Container.Bind<OptionsMenu>().FromInstance(m_optionsMenu);
        }
    }
}