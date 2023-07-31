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
                if (!m_mapsData[i].Unlocked && !m_mapsData[i].CheckUnlock())
                {
                    m_mapsNodes[i].image.sprite = m_mapNodeSprites[0];
                    m_mapsNodes[i].interactable = false;
                }
                else
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
                        if (!m_mapsData[i].Concluded && !m_mapsData[i].CheckConclusion()) m_mapsNodes[i].image.sprite = m_mapNodeSprites[2];
                        else m_mapsNodes[i].image.sprite = m_mapNodeSprites[3];
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