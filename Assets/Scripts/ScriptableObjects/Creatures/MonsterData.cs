using System.Collections.Generic;
using UnityEngine;

namespace Pinbattlers.Enemies
{
    [CreateAssetMenu(fileName = "Monster", menuName = "EntityData/Monster")]
    public class MonsterData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Illustration { get; private set; }
        [field: SerializeField] public int Life { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Defense { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int QuantityKilled { get; private set; }
        [field: SerializeField] public List<string> States { get; private set; }
        [field: SerializeField] public bool IsChampion { get; set; }
    }
}