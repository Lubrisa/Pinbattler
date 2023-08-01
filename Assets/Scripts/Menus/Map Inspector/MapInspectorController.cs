using Pinbattlers.Scriptables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class MapInspectorController : MonoBehaviour
    {
        
        private TMP_Text m_mapName;
        private TMP_Text m_mapDescription;
        private Image m_mapIllustration;
        private TMP_Text m_mapHighScore;

        [Inject]
        private void Constructor(TMP_Text mapName, [Inject(Id = "MapDescription")] TMP_Text mapDescription, Image mapIllustration, [Inject(Id = "MapHighScore")] TMP_Text mapHighScore)
        {
            m_mapName = mapName;
            m_mapDescription = mapDescription;
            m_mapIllustration = mapIllustration;
            m_mapHighScore = mapHighScore;
        }

        public void UpdateInfo(MapsData mapData)
        {
            m_mapName.text = mapData.MapName;
            m_mapDescription.text = mapData.MapDescription;
            m_mapIllustration.sprite = mapData.MapIllustration;
            m_mapHighScore.text = "Maior pontuação: " + mapData.MapHighScore.ToString();
        }

        public void LoadMap()
        {
        }
    }
}