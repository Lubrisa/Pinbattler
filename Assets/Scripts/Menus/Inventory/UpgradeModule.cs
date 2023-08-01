using Pinbattlers.Player;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Pinbattlers.Menus
{
    public class UpgradeModule : MonoBehaviour
    {
        [Inject]
        private PlayerData m_instance;

        private enum AttributeType
        {
            Life,
            Attack,
            Defense
        }

        [SerializeField] private TMP_Text m_level;
        [SerializeField] private TMP_Text m_value;
        [SerializeField] private TMP_Text m_upgradeLabel;
        [SerializeField] private Button m_upgradeButton;

        [SerializeField] private AttributeType m_type;

        [SerializeField] private GameEvent m_essencesUpdate;

        public void UpdateValues()
        {
            if (m_type == AttributeType.Life)
            {
                // Level do atributo = Valor do modificador / 10 + 1.
                m_level.text = "Nível do Atributo: " + (m_instance.LifeModifier / 10 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + (m_instance.Life + m_instance.LifeModifier).ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + (Level do atributo + 1) * 2 - 2.
                m_upgradeLabel.text = (m_instance.LifeModifier / 10 + 1) < 26 ? "Custo: " + ((m_instance.LifeModifier / 10 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (m_instance.Life + m_instance.LifeModifier + (m_instance.LifeModifier / 10 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((m_instance.Essences < (m_instance.LifeModifier / 10 + 1) * 50)
                    || m_instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
            else if (m_type == AttributeType.Attack)
            {
                // Level do atributo = Valor do modificador / 10 + 1.
                m_level.text = "Nível do Atributo: " + (m_instance.AttackModifier / 10 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + (m_instance.Attack + m_instance.AttackModifier).ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + Level do atributo * 2 - 2.
                m_upgradeLabel.text = (m_instance.AttackModifier / 10 + 1) < 26 ? "Custo: " + ((m_instance.AttackModifier / 10 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (m_instance.Attack + m_instance.AttackModifier + (m_instance.AttackModifier / 10 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((m_instance.Essences < (m_instance.AttackModifier / 10 + 1) * 50)
                    || m_instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
            else
            {
                // Level do atributo = Valor do modificador / 2 + 1.
                m_level.text = "Nível do Atributo: " + (m_instance.Defense / 2 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + m_instance.Defense.ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + Level do atributo * 2 - 2.
                m_upgradeLabel.text = (m_instance.Defense / 10 + 1) < 26 ? "Custo: " + ((m_instance.Defense / 2 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (m_instance.Defense + (m_instance.Defense / 2 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((m_instance.Essences < (m_instance.Defense / 2 + 1) * 50)
                    || m_instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
        }

        public void Upgrade(int attributeIndex)
        {
            m_instance.UpgradeAttribute(attributeIndex);
            m_essencesUpdate.Raise();
        }
    }
}