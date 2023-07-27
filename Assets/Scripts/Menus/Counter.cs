using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pinbattlers.Player.Resouces
{
    public class Counter : MonoBehaviour
    {
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
            if (m_moneyType == MoneyType.Points) m_text.text = "Seus Pontos: " + PlayerData.Instance.Points;
            else if (m_moneyType == MoneyType.Stars) m_text.text = "Suas Estrelas: " + PlayerData.Instance.Stars;
            else m_text.text = "Suas Ess�ncias: " + PlayerData.Instance.Essences;
        }
    }
}