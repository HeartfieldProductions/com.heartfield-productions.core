using System;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(ReflectionProbe)), DisallowMultipleComponent]
sealed class ReflectionProbeUpdater : MonoBehaviour
{
    [NonSerialized] ReflectionProbe probe;
    [NonSerialized] float currRate;
    [SerializeField] int rate = 30;

    void Awake()
    {
        probe = GetComponent<ReflectionProbe>();
        probe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
    }

    void LateUpdate()
    {
        currRate += Time.deltaTime * rate;

        if (currRate >= 1)
        {
            probe.RenderProbe();
            currRate = 0;
        }
    }
}