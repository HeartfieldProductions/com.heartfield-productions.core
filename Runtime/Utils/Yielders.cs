using UnityEngine;
using System.Collections.Generic;

namespace Heartfield.Utils
{
    public static class Yielders
    {
        static Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(64);
        //static Dictionary<Func<bool>, WaitUntil> _waitUntil = new Dictionary<Func<bool>, WaitUntil>(64);
        //static Dictionary<bool, WaitFor> _waitFor = new Dictionary<bool, WaitFor>(100);

        static WaitForEndOfFrame _waitEndOfFrame = new WaitForEndOfFrame();
        static WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        /// <summary>
        /// Waits until the end of the frame after Unity has rendererd every Camera and GUI, just before displaying the frame on screen. 
        /// </summary>
        public static WaitForEndOfFrame WaitEndOfFrame => _waitEndOfFrame;

        /// <summary>
        /// Waits until next fixed frame rate update function. See Also: MonoBehaviour.FixedUpdate.
        /// </summary>
        public static WaitForFixedUpdate WaitFixedUpdate => _waitForFixedUpdate;

        /// <summary>
        /// Suspends the coroutine execution for the given amount of seconds using scaled time. 
        /// </summary>
        /// <param name="seconds">Delay execution by the amount of time in seconds.</param>
        /// <returns>Delay execution by the amount of time in seconds.</returns>
        public static WaitForSeconds WaitSeconds(float seconds)
        {
            if (!_timeInterval.ContainsKey(seconds))
                _timeInterval.Add(seconds, new WaitForSeconds(seconds));

            return _timeInterval[seconds];
        }

        //public static WaitUntil Wait(Func<bool> pedicate)
        //{
        //    if (!_waitUntil.ContainsKey(pedicate))
        //        _waitUntil.Add(pedicate, new WaitUntil(pedicate));

        //    return _waitUntil[pedicate];
        //}

        /*public static WaitFor Wait(bool condition)
        {
            if (!_waitFor.ContainsKey(condition))
                _waitFor.Add(condition, new WaitFor(condition));

            return _waitFor[condition];
        }*/
    }
}