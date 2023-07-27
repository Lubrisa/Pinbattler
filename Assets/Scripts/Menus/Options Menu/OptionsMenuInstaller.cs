using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Pinbattlers.Menus
{
    public class OptionsMenuInstaller : MonoInstaller
    {
        [SerializeField] private GameObject[] m_sessions;
        [SerializeField] private AudioMixer m_mixer;

        public override void InstallBindings()
        {
            Container.Bind<GameObject[]>().FromInstance(m_sessions);
            Container.Bind<AudioMixer>().FromInstance(m_mixer);
        }
    }
}