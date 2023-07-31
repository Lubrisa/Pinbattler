using UnityEngine;
using Zenject;

public class DependentObj : MonoBehaviour
{
    [Inject]
    private TestObj m_testObj;
}