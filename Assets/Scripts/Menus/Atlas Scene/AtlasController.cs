using Pinbattlers.Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class AtlasController : MonoBehaviour
    {
        [SerializeField] private GameObject m_confirmationMenuExit;

        [SerializeField] private Button[] m_mapsNodes;
        [SerializeField] private MapsData[] m_mapsData;
        [SerializeField] private Sprite[] m_mapNodeSprites = new Sprite[4];

        private void Start()
        {
            for (int i = 0; i < m_mapsNodes.Length; i++)
            {
                bool unlocked = true;
                foreach (bool b in m_mapsData[i].Unlocked)
                {
                    if (!b)
                    {
                        unlocked = false;
                        m_mapsNodes[i].image.sprite = m_mapNodeSprites[0];
                        m_mapsNodes[i].interactable = false;
                        break;
                    }
                }

                if (unlocked)
                {
                    bool areChallengesConcluded = true;
                    foreach (BaseChallenge bc in m_mapsData[i].MapChallenges)
                    {
                        if (!bc.Concluded)
                        {
                            areChallengesConcluded = false;
                            m_mapsNodes[i].image.sprite = m_mapNodeSprites[1];
                            break;
                        }
                    }

                    if (areChallengesConcluded)
                    {
                        bool areModifiersConcluded = true;
                        foreach (BaseDifficultyModifier bdm in m_mapsData[i].MapModifiers)
                        {
                            if (!bdm.Concluded)
                            {
                                areModifiersConcluded = false;
                                m_mapsNodes[i].image.sprite = m_mapNodeSprites[2];
                                break;
                            }
                        }

                        if (areModifiersConcluded) m_mapsNodes[i].image.sprite = m_mapNodeSprites[3];
                    }
                }
            }
        }

        public void OnExitButtonClick()
        {
            Instantiate(m_confirmationMenuExit);
        }
    }
}