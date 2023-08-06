using Pinbattlers.Menus;
using Pinbattlers.Player.Resouces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Scriptables
{
    [Serializable]
    public abstract class BaseDifficultyModifier : ScriptableObject
    {
        public abstract string Description { get; protected set; }

        public abstract bool IsEnabled { get; set; }

        public abstract bool Concluded { get; protected set; }

        public abstract Reward Rewards { get; protected set; }

        public abstract void StartEffect();

        public abstract bool MissionVerification();

        public virtual void Reset() => Concluded = false;

        protected virtual void GenerateRewards()
        {
            int pointsReward = new System.Random().Next(Rewards.PointsRewardRange[0], Rewards.PointsRewardRange[1] + 1);
            GameOverMenuController.Instance.Score += pointsReward;

            int essencesReward = new System.Random().Next(Rewards.EssencesRewardRange[0], Rewards.EssencesRewardRange[1] + 1);
            GameOverMenuController.Instance.Essences += essencesReward;

            if (!Concluded) GameOverMenuController.Instance.Stars += Rewards.Star;

            if (VerifyRelicDrop(out Relic choosenRelic)) GameOverMenuController.Instance.Relics.Add(choosenRelic);

            if (VerifyConsumableDrop(out List<Consumable> consumables))
            {
                foreach (Consumable c in consumables)
                {
                    GameOverMenuController.Instance.Consumables.Add(c);
                }
            }
        }

        protected bool VerifyRelicDrop(out Relic choosenRelic)
        {
            if (Rewards.Relics.Length == 0)
            {
                choosenRelic = null;
                return false;
            }

            int dropChance = new System.Random().Next(0, 101);

            List<Relic> possibleRelics;

            if (dropChance < Rewards.CommomDropChance)
            {
                choosenRelic = null;
                return false;
            }
            else if (dropChance < Rewards.UncommomDropChance) possibleRelics = MakeRelicList(Item.Rarity.RarityTypes.Commom);
            else if (dropChance < Rewards.RareDropChance) possibleRelics = MakeRelicList(Item.Rarity.RarityTypes.Uncommom);
            else if (dropChance < Rewards.LegendaryDropChance) possibleRelics = MakeRelicList(Item.Rarity.RarityTypes.Rare);
            else possibleRelics = MakeRelicList(Item.Rarity.RarityTypes.Legendary);

            choosenRelic = possibleRelics[new System.Random().Next(0, possibleRelics.Count - 1)];
            return true;
        }

        protected List<Relic> MakeRelicList(Item.Rarity.RarityTypes rarity)
        {
            List<Relic> relicsToReturn = new List<Relic>();

            for (int i = 0; i < Rewards.Relics.Length; i++)
            {
                if (Rewards.Relics[i].ItemRarity.RarityType == rarity)
                {
                    relicsToReturn.Add(Rewards.Relics[i]);
                }
            }

            return relicsToReturn;
        }

        protected bool VerifyConsumableDrop(out List<Consumable> consumables)
        {
            if (Rewards.ConsumablesQuantity == 0)
            {
                consumables = null;
                return false;
            }

            consumables = new List<Consumable>();

            for (int i = 0; i < Rewards.ConsumablesQuantity; i++)
            {
                int dropChance = new System.Random().Next(0, 101);

                List<Consumable> possibleConsumables;

                if (dropChance < Rewards.UncommomDropChance) possibleConsumables = MakeConsumableList(Item.Rarity.RarityTypes.Commom);
                else if (dropChance < Rewards.RareDropChance) possibleConsumables = MakeConsumableList(Item.Rarity.RarityTypes.Uncommom);
                else if (dropChance < Rewards.LegendaryDropChance) possibleConsumables = MakeConsumableList(Item.Rarity.RarityTypes.Rare);
                else possibleConsumables = MakeConsumableList(Item.Rarity.RarityTypes.Legendary);

                Consumable save = possibleConsumables[new System.Random().Next(0, possibleConsumables.Count - 1)];
                if (consumables.Contains(save)) i--;
                else consumables.Add(possibleConsumables[new System.Random().Next(0, possibleConsumables.Count - 1)]);

                consumables[i].Quantity = GenerateConsumableQuantity(consumables[i].ItemRarity.RarityType);
            }
            return true;
        }

        protected List<Consumable> MakeConsumableList(Item.Rarity.RarityTypes rarity)
        {
            List<Consumable> consumablesToReturn = new List<Consumable>();

            for (int i = 0; i < Rewards.Consumables.Length; i++)
            {
                if (Rewards.Consumables[i].ItemRarity.RarityType == rarity)
                {
                    consumablesToReturn.Add(Rewards.Consumables[i]);
                }
            }

            return consumablesToReturn;
        }

        protected int GenerateConsumableQuantity(Item.Rarity.RarityTypes rarity)
        {
            if (rarity == Item.Rarity.RarityTypes.Commom) return new System.Random().
                    Next(Rewards.CommomDropQuantity[0], Rewards.CommomDropQuantity[1]);
            else if (rarity == Item.Rarity.RarityTypes.Uncommom) return new System.Random().
                    Next(Rewards.UncommomDropQuantity[0], Rewards.UncommomDropQuantity[1]);
            else if (rarity == Item.Rarity.RarityTypes.Rare) return new System.Random().
                    Next(Rewards.RareDropQuantity[0], Rewards.RareDropQuantity[1]);
            else return new System.Random().Next(Rewards.LegendaryDropQuantity[0], Rewards.LegendaryDropQuantity[1]);
        }

        [Serializable]
        public class Reward
        {
            // Reward in Points (a range between two values to generate a aleatory number).
            [field: SerializeField] public int[] PointsRewardRange { get; private set; } = new int[2];

            // Reward in Essences (a range between two values to generate a aleatory number).
            [field: SerializeField] public int[] EssencesRewardRange { get; private set; } = new int[2];

            // Reward in Star.
            [field: SerializeField] public int Star { get; private set; }

            // Relics Pool.
            [field: SerializeField] public Relic[] Relics { get; private set; }

            // Consumables Pool.
            [field: SerializeField] public Consumable[] Consumables { get; private set; }

            [field: SerializeField] public int ConsumablesQuantity { get; private set; }

            // Rarities drop chance & drop quantity for each rarity.
            [field: SerializeField] public int CommomDropChance { get; private set; }

            [field: SerializeField] public int[] CommomDropQuantity { get; private set; } = new int[2];

            [field: SerializeField] public int UncommomDropChance { get; private set; }
            [field: SerializeField] public int[] UncommomDropQuantity { get; private set; } = new int[2];

            [field: SerializeField] public int RareDropChance { get; private set; }
            [field: SerializeField] public int[] RareDropQuantity { get; private set; } = new int[2];

            [field: SerializeField] public int LegendaryDropChance { get; private set; }
            [field: SerializeField] public int[] LegendaryDropQuantity { get; private set; } = new int[2];
        }
    }
}