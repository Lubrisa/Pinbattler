using UnityEngine;
using Zenject;

public class TestObj : ITickable
{
    public void Tick()
    {
        Debug.Log("Teste");
    }
}