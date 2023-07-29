using System;
using UnityEngine;
using Zenject;

[Serializable]
public class RandomTest
{
    [field: SerializeField] public int Value { get; private set; }

    [Inject]
    public RandomTest()
    {
        Value = new System.Random().Next(0, 101);
    }
}