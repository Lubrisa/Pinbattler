using Pinbattlers.Player.Resouces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "EntityData/Player")]
    [Serializable]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public int Life { get; private set; }
        [field: SerializeField] public int LifeModifier { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int AttackModifier { get; private set; }
        [field: SerializeField] public int Defense { get; private set; }
        [field: SerializeField] public List<Sprite> Skins { get; private set; }
        [field: SerializeField] public Sprite SkinEquiped { get; private set; }
        [field: SerializeField] public List<Ability> Abilities { get; private set; }
        [field: SerializeField] public Ability AbilityEquiped { get; private set; }
        [field: SerializeField] public List<Relic> Relics { get; private set; }
        [field: SerializeField] public Relic RelicEquiped { get; private set; }
        [field: SerializeField] public List<Consumable> Consumables { get; private set; }
        [field: SerializeField] public int Points { get; private set; }
        [field: SerializeField] public int Stars { get; private set; }
        [field: SerializeField] public int Essences { get; private set; }

        public void EquipAbility(Ability ability)
        {
            AbilityEquiped = ability;
        }

        public void EquipRelic(Relic relic)
        {
            RelicEquiped = relic;
        }

        public void UpgradeAbility(int abilityIndex)
        {
            Stars -= Abilities[abilityIndex].Level;
            Abilities[abilityIndex].Level += 1;
        }

        public void UpgradeAttribute(int attributeIndex)
        {
            if (attributeIndex == 0) LifeModifier += 2;
            else if (attributeIndex == 1) AttackModifier += 2;
            else Defense += 2;
        }

        public void UpdateInventory(int points, int stars, int essences,
            List<Consumable> consumables, List<Relic> relics, Ability ability)
        {
            Points += points;
            Stars += stars;
            Essences += essences;

            if (ability != null && !Abilities.Contains(ability)) Abilities.Add(ability);

            foreach (Relic r in relics)
            {
                Relics.Add(r);
            }

            foreach (Consumable c in consumables)
            {
                foreach (Consumable con in Consumables)
                {
                    if (con.Name == c.Name) con.Quantity += c.Quantity;
                    else Consumables.Add(c);
                }
            }
        }
    }
}