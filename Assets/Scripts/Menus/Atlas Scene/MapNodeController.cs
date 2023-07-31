using Pinbattlers.Menus;
using Pinbattlers.Scriptables;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MapNodeController : MonoBehaviour
{
    private Button m_node;
    [SerializeField] private MapsData m_mapData;

    [Inject]
    private Sprite[] m_nodeSprites;

    private void Start()
    {
        m_node = GetComponent<Button>();

        if (!m_mapData.Unlocked && !m_mapData.CheckUnlock())
        {
            m_node.image.sprite = m_nodeSprites[0];
            m_node.interactable = false;
        }
        else
        {
            bool areChallengesConcluded = true;
            foreach (BaseChallenge bc in m_mapData.MapChallenges)
            {
                if (!bc.Concluded)
                {
                    areChallengesConcluded = false;
                    m_node.image.sprite = m_nodeSprites[1];
                }
            }

            if (areChallengesConcluded)
            {
                if (!m_mapData.Concluded && !m_mapData.CheckConclusion()) m_node.image.sprite = m_nodeSprites[2];
                else m_node.image.sprite = m_nodeSprites[3];
            }
        }
    }
}