using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heartfield.Utils;

namespace Heartfield.UI
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class LoadingTipsCycle : MonoBehaviour
    {
        [SerializeField] int maxDisplayTime = 10;

        List<GameObject> tips = new List<GameObject>();
        Coroutine cycleCoroutine;

        void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var go = transform.GetChild(i).gameObject;
                tips.Add(go);
                go.SetActive(false);
            }
        }

        void OnEnable()
        {
            if (cycleCoroutine != null)
                cycleCoroutine = null;

            cycleCoroutine = StartCoroutine(Cycle());
        }

        void OnDisable()
        {
            StopCoroutine(cycleCoroutine);
        }

        IEnumerator Cycle()
        {
            GameObject lastTip = null;

            while (true)
            {
                if (lastTip != null)
                    lastTip.SetActive(false);

                int index = Random.Range(0, tips.Count - 1);
                var currentTip = tips[index];
                currentTip.SetActive(true);
                lastTip = currentTip;

                yield return Yielders.WaitSeconds(maxDisplayTime);
            }
        }
    }
}