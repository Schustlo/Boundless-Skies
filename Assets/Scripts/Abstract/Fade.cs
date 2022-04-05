/* Copyright (C) Dundees Games LLC 2020 - All Rights Reserved
 * Scott Tongue
 *  Fade between numbers
 * 
 */

using System.Collections;
using UnityEngine;

namespace UI
{
    public abstract class Fade : MonoBehaviour
    {

        protected Coroutine _fade = null;

      
        #region public

        public virtual bool IsFading()
        {
            if (_fade == null)
                return false;

            return true;
        }


        public virtual void StopFade()
        {
            if (_fade == null)
                return;
            StopCoroutine(_fade);
            _fade = null;
        }

        #endregion

        #region protected

        protected virtual void ObjectToFade(float amount)
        {

        }

        protected virtual IEnumerator FadeObject(float time, float target)
        {
            float timeFinish = Time.time + time;
            float amount = target / time;
            while (timeFinish > Time.time)
            {
                ObjectToFade(amount);
                yield return null;
            }

            _fade = null;
        }
        #endregion
    }
}