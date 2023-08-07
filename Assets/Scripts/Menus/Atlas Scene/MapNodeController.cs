using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class MapNodeController : MonoBehaviour
    {
        [SerializeField] private MapData m_mapData;

        private Button m_node;

        [Inject]
        private Sprite[] m_nodeSprites;

        private void Start()
        {
            m_node = GetComponent<Button>();

            if (!m_mapData.Unlocked())
            {
                m_node.image.sprite = m_nodeSprites[0];
                m_node.interactable = false;
            }
            else
            {
                if (!m_mapData.Concluded()) m_node.image.sprite = m_nodeSprites[1];
                else
                {
                    if (!m_mapData.Cleared()) m_node.image.sprite = m_nodeSprites[2];
                    else m_node.image.sprite = m_nodeSprites[3];
                }
            }
        }
    }
}