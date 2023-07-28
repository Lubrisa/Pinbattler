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
        [Inject(Id = "name")]
        private TMP_Text m_mapName;

        [Inject(Id = "description")]
        private TMP_Text m_mapDescription;

        private Image m_mapIllustration;

        [Inject(Id = "challenges")]
        private TMP_Text[] m_challenges;

        [Inject(Id = "modifiers")]
        private TMP_Text[] m_modifiers;

        [Inject(Id = "highscore")]
        private TMP_Text m_mapHighScore;

        public static MapsData[] MapData { get; private set; }
        public static int MapIndex { get; private set; }

        [Inject]
        private void Constructor(Image mapIllustration, MapsData[] mapData)
        {
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

            // Iterates through the challenges list.
            // If the map has a challenge in the index, the challenge description is copied to the text,
            // otherwise, the text becomes blank.
            for (int i = 0; i < m_challenges.Length; i++)
            {
                if (i < MapData[mapIndex].MapChallenges.Length)
                {
                    if (MapData[mapIndex].MapChallenges[i].Concluded) m_challenges[i].fontStyle = FontStyles.Strikethrough;
                    else m_challenges[i].fontStyle = FontStyles.Normal;
                    m_challenges[i].text = MapData[mapIndex].MapChallenges[i].Description;
                }
                else m_challenges[i].text = "";
            }

            for (int i = 0; i < m_modifiers.Length; i++)
            {
                if (i < MapData[mapIndex].MapModifiers.Length) m_modifiers[i].text = MapData[mapIndex].MapModifiers[i].Description;
                else m_modifiers[i].transform.parent.gameObject.SetActive(false);
            }

            m_mapHighScore.text = "Maior pontuação: " + MapData[mapIndex].MapHighScore.ToString();
        }

        public void OnModifierToggleValueChange(int modifierIndex)
        {
            MapData[MapIndex].MapModifiers[modifierIndex].IsEnabled = !MapData[MapIndex].MapModifiers[modifierIndex].IsEnabled;
        }

        public void LoadMap()
        {
            SceneManager.LoadScene(MapIndex + 3);
        }
    }
}