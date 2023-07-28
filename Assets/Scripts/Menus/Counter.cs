using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Pinbattlers.Player.Resouces
{
    public class Counter : MonoBehaviour
    {
        [Inject]
        private PlayerData m_instance;

        private enum MoneyType
        {
            Points,
            Stars,
            Essences
        }

        [SerializeField] private MoneyType m_moneyType;
        private TMP_Text m_text;

        private void Start()
        {
            m_text = GetComponent<TMP_Text>();

            SetValue();
        }

        public void SetValue()
        {
            if (m_moneyType == MoneyType.Points) m_text.text = "Seus Pontos: " + m_instance.Points;
            else if (m_moneyType == MoneyType.Stars) m_text.text = "Suas Estrelas: " + m_instance.Stars;
            else m_text.text = "Suas Essências: " + m_instance.Essences;
        }
    }
}