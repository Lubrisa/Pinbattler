using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class AudioMixerInstaller : MonoInstaller
{
    [SerializeField] private AudioMixer m_audioMixer;

    public override void InstallBindings()
    {
        Container.Bind<AudioMixer>().FromInstance(m_audioMixer).AsSingle();
    }
}