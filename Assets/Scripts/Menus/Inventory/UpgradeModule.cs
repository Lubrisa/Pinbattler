using Pinbattlers.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pinbattlers.Menus
{
    public class UpgradeModule : MonoBehaviour
    {
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

        public void UpdateValues()
        {
            if (m_type == AttributeType.Life)
            {
                // Level do atributo = Valor do modificador / 10 + 1.
                m_level.text = "Nível do Atributo: " + (PlayerData.Instance.LifeModifier / 10 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + (PlayerData.Instance.Life + PlayerData.Instance.LifeModifier).ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + (Level do atributo + 1) * 2 - 2.
                m_upgradeLabel.text = (PlayerData.Instance.LifeModifier / 10 + 1) < 26 ? "Custo: " + ((PlayerData.Instance.LifeModifier / 10 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (PlayerData.Instance.Life + PlayerData.Instance.LifeModifier + (PlayerData.Instance.LifeModifier / 10 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((PlayerData.Instance.Essences < (PlayerData.Instance.LifeModifier / 10 + 1) * 50)
                    || PlayerData.Instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
            else if (m_type == AttributeType.Attack)
            {
                // Level do atributo = Valor do modificador / 10 + 1.
                m_level.text = "Nível do Atributo: " + (PlayerData.Instance.AttackModifier / 10 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + (PlayerData.Instance.Attack + PlayerData.Instance.AttackModifier).ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + Level do atributo * 2 - 2.
                m_upgradeLabel.text = (PlayerData.Instance.AttackModifier / 10 + 1) < 26 ? "Custo: " + ((PlayerData.Instance.AttackModifier / 10 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (PlayerData.Instance.Attack + PlayerData.Instance.AttackModifier + (PlayerData.Instance.AttackModifier / 10 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((PlayerData.Instance.Essences < (PlayerData.Instance.AttackModifier / 10 + 1) * 50)
                    || PlayerData.Instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
            else
            {
                // Level do atributo = Valor do modificador / 2 + 1.
                m_level.text = "Nível do Atributo: " + (PlayerData.Instance.Defense / 2 + 1).ToString();
                // Valor total do atributo = Valor do atributo base + Valor do modificador.
                m_value.text = "Valor do Atributo: " + PlayerData.Instance.Defense.ToString();
                // Custo do upgrade = Level do atributo * 50.
                // Novo valor do atributo = Valor total atual + Level do atributo * 2 - 2.
                m_upgradeLabel.text = (PlayerData.Instance.Defense / 10 + 1) < 26 ? "Custo: " + ((PlayerData.Instance.Defense / 2 + 1) * 50).ToString() +
                    "\nNovo Valor: " + (PlayerData.Instance.Defense + (PlayerData.Instance.Defense / 2 + 2) * 2 - 2).ToString() :
                    "Nível máximo atingido!";

                if ((PlayerData.Instance.Essences < (PlayerData.Instance.Defense / 2 + 1) * 50)
                    || PlayerData.Instance.LifeModifier / 10 + 1 == 26) m_upgradeButton.interactable = false;
                else m_upgradeButton.interactable = true;
            }
        }

        public void Upgrade(int attributeIndex)
        {
            PlayerData.Instance.UpgradeAttribute(attributeIndex);
        }
    }
}