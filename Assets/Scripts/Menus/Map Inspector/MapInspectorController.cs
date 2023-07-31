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

        private TMP_Text[] m_challenges;

        private Toggle[] m_mapModifiersToggle;

        private TMP_Text[] m_modifiersText;

        private TMP_Text m_mapHighScore;

        public static MapsData[] MapData { get; private set; }
        public static int MapIndex { get; private set; }

        [Inject]
        private void Constructor([Inject(Id = "name")] TMP_Text mapName, [Inject(Id = "description")] TMP_Text mapDescription,
            [Inject(Id = "challenges")] TMP_Text[] mapChallenges, Image mapIllustration, MapsData[] mapData)
        {
            m_mapName = mapName;
            m_mapDescription = mapDescription;
            m_challenges = mapChallenges;
            m_mapIllustration = mapIllustration;
            MapData = mapData;
        }

        public void UpdateInfo(int mapIndex)
        {
            // Set map index.
            MapIndex = mapIndex;

            // Set map name, description and illustration.
            m_mapName.text = MapData[mapIndex].MapName;
            m_mapDescription.text = MapData[mapIndex].MapDescription;
            m_mapIllustration.sprite = MapData[mapIndex].MapIllustration;

            bool areChallengesConcluded = true;
            // Iterates through the challenges list.
            // If the map has a challenge in the index, the challenge description is copied to the text,
            // otherwise, the text becomes blank.
            for (int i = 0; i < m_challenges.Length; i++)
            {
                if (i < MapData[mapIndex].MapChallenges.Length)
                {
                    if (MapData[mapIndex].MapChallenges[i].Concluded) m_challenges[i].fontStyle = FontStyles.Strikethrough;
                    else
                    {
                        m_challenges[i].fontStyle = FontStyles.Normal;
                        areChallengesConcluded = false;
                    }
                    m_challenges[i].text = MapData[mapIndex].MapChallenges[i].Description;
                }
                else m_challenges[i].text = "";
            }

            for (int i = 0; i < m_mapModifiersToggle.Length; i++)
            {
                if (i < MapData[mapIndex].MapModifiers.Length)
                {
                    m_mapModifiersToggle[i].isOn = false;
                    if (!areChallengesConcluded) m_mapModifiersToggle[i].interactable = false;
                    m_modifiersText[i].text = MapData[mapIndex].MapModifiers[i].Description;
                }
                else m_modifiersText[i].transform.parent.gameObject.SetActive(false);
            }

            m_mapHighScore.text = "Maior pontuação: " + MapData[mapIndex].MapHighScore.ToString();
        }

        public void OnModifierToggleValueChange(int modifierIndex)
        {
            MapData[MapIndex].MapModifiers[modifierIndex].IsEnabled = m_mapModifiersToggle[modifierIndex].isOn;
        }

        public void LoadMap()
        {
            SceneManager.LoadScene(MapIndex + 3);
        }
    }
}