using ScriptableObjectArchitecture;
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

        [SerializeField] private TMP_Text[] m_mapChallenges;
        private Toggle[] m_mapDificultyModifiers;

        public int MapPath { get; set; }

        [SerializeField] private IntVariable m_fixedScoreMultiplier;

        [Inject]
        private void Constructor(
            [Inject(Id = "MapName")] TextMeshProUGUI mapName,
            [Inject(Id = "MapDescription")] TextMeshProUGUI mapDescription,
            [Inject(Id = "MapIcon")] Image mapIllustration,
            [Inject(Id = "MapHighScore")] TextMeshProUGUI mapHighScore,
            [Inject(Id = "MapChallenges")] TextMeshProUGUI[] mapChallenges,
            [Inject(Id = "MapModifiers")] Toggle[] mapDificultyModifiers)
        {
            m_mapName = mapName;
            m_mapDescription = mapDescription;
            m_mapIllustration = mapIllustration;
            m_mapHighScore = mapHighScore;
            m_mapChallenges = mapChallenges;
            m_mapDificultyModifiers = mapDificultyModifiers;
        }

        public void OnUpdateInfoRequest(MapData mapData)
        {
            m_mapName.text = mapData.MapName;
            m_mapDescription.text = mapData.MapDescription;
            m_mapIllustration.sprite = mapData.MapIllustration;
            m_mapHighScore.text = "Maior pontuação: " + mapData.MapHighScore.ToString();

            // Setting challenges
            for (int i = 0; i < m_mapChallenges.Length; i++)
            {
                if (i < mapData.MapChallenges.Length)
                {
                    m_mapChallenges[i].text = mapData.MapChallenges[i].Description;

                    m_mapChallenges[i].fontStyle = mapData.MapChallenges[i].Concluded ?
                        FontStyles.Strikethrough : FontStyles.Normal;

                    if (!m_mapChallenges[i].gameObject.activeSelf) m_mapChallenges[i].gameObject.SetActive(true);
                }
                else if (m_mapChallenges[i].gameObject.activeSelf) m_mapChallenges[i].gameObject.SetActive(false);
            }

            // Setting modifiers
            for (int i = 0; i < m_mapDificultyModifiers.Length; i++)
            {
                if (i < mapData.MapModifiers.Length)
                {
                    m_mapDificultyModifiers[i].isOn = false;
                    mapData.MapModifiers[i].IsEnabled = false;
                    m_mapDificultyModifiers[i].interactable = mapData.Concluded();

                    TMP_Text modifierDescription = m_mapDificultyModifiers[i].gameObject.
                        GetComponentInChildren<TextMeshProUGUI>();
                    modifierDescription.text = mapData.MapModifiers[i].Description;

                    m_mapDificultyModifiers[i].gameObject.SetActive(true);
                }
                else m_mapDificultyModifiers[i].gameObject.SetActive(false);
            }
        }

        public void OnTravelButtonClick() => SceneManager.LoadScene(MapPath);
    }
}