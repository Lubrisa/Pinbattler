using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class MapInspectorInstaler : MonoInstaller
    {
        private MapInspectorController m_controller;
        [SerializeField] private MapsData[] m_mapsData;

        [SerializeField] private TMP_Text m_mapName;
        [SerializeField] private TMP_Text m_mapDescription;
        [SerializeField] private Image m_mapIllustration;
        [SerializeField] private TMP_Text[] m_challenges;
        [SerializeField] private TMP_Text[] m_modifiers;
        [SerializeField] private TMP_Text m_mapHighScore;

        public override void InstallBindings()
        {
            m_controller = GetComponent<MapInspectorController>();

            Container.Bind<MapInspectorController>().FromInstance(m_controller);
            Container.Bind<MapsData[]>().FromInstance(m_mapsData);
            Container.Bind<TMP_Text>().WithId("name").FromInstance(m_mapName);
            Container.Bind<TMP_Text>().WithId("description").FromInstance(m_mapDescription);
            Container.Bind<Image>().FromInstance(m_mapIllustration);
            Container.Bind<TMP_Text[]>().WithId("challenges").FromInstance(m_challenges);
            Container.Bind<TMP_Text[]>().WithId("modifiers").FromInstance(m_modifiers);
            Container.Bind<TMP_Text>().WithId("highscore").FromInstance(m_mapHighScore);
        }
    }
}