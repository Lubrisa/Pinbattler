using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;
using Zenject;

public class ObjDependente : MonoBehaviour
{
    [SerializeField] private RandomTest m_test;
    [SerializeField] private int m_count;

    [Inject]
    private void Constructor(RandomTest test)
    {
        m_test = test;
    }

    private void Update()
    {
        m_count = m_test.Value;
    }
}