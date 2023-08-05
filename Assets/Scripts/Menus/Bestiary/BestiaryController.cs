using Pinbattlers.Enemies;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class BestiaryController : MonoBehaviour
    {
        private TMP_Text m_enemyName;
        private Image m_enemyIllustration;
        private TMP_Text m_enemyLore;
        private TMP_Text m_enemyQuantityKilled;
        private Button m_nextPageButton;
        private Button m_previousPageButton;
        [SerializeField] private MonsterDataArray[] m_enemiesData;

        private int m_session;
        private int m_page;

        [Inject]
        public void Constructor(
            [Inject(Id = "EnemyName")] TextMeshProUGUI enemyName,
            [Inject(Id = "EnemyLore")] TextMeshProUGUI enemyLore,
            [Inject(Id = "EnemyIcon")] Image enemyIllustration,
            [Inject(Id = "EnemyDefeated")] TextMeshProUGUI enemyQuantityKilled,
            [Inject(Id = "EnemyNextPage")] Button nextPage,
            [Inject(Id = "EnemyPreviousPage")] Button previousPage)
        {
            m_enemyName = enemyName;
            m_enemyLore = enemyLore;
            m_enemyIllustration = enemyIllustration;
            m_enemyQuantityKilled = enemyQuantityKilled;
            m_nextPageButton = nextPage;
            m_previousPageButton = previousPage;
        }

        public void UpdateInfo(int page)
        {
            m_page = page;

            if (m_enemiesData[m_session].Data[page].QuantityKilled > 0)
            {
                m_enemyName.text = m_enemiesData[m_session].Data[page].Name;
                m_enemyIllustration.sprite = m_enemiesData[m_session].Data[page].Illustration;
                m_enemyLore.text = m_enemiesData[m_session].Data[page].Description;
                m_enemyQuantityKilled.text = "Quantidade derrotada: " + m_enemiesData[m_session].Data[page].QuantityKilled.ToString();
            }
            else
            {
                m_enemyName.text = "???";
                m_enemyIllustration.sprite = null;
                m_enemyLore.text = "???";
                m_enemyQuantityKilled.text = "???";
            }
        }

        public void ChangeSession(int session)
        {
            m_session = session;
            m_previousPageButton.interactable = false;
            m_nextPageButton.interactable = true;
            UpdateInfo(0);
        }

        public void OnNextPageButtonClick()
        {
            if (m_page + 1 == m_enemiesData[m_session].Data.Length - 1) m_nextPageButton.interactable = false;
            if (!m_previousPageButton.interactable) m_previousPageButton.interactable = true;
            UpdateInfo(m_page + 1);
        }

        public void OnPreviousPageButtonClick()
        {
            if (m_page - 1 == 0) m_previousPageButton.interactable = false;
            if (!m_nextPageButton.interactable) m_nextPageButton.interactable = true;
            UpdateInfo(m_page - 1);
        }

        [Serializable]
        private sealed class MonsterDataArray
        {
            [SerializeField] public MonsterData[] Data;
        }

        
    }
}