using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomInputKey;

public class intervalkey : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
namespace CustomInputKey
{
    /// <summary>
    /// Custom InputKey
    /// </summary>
    public static class CustomInput
    {
        static bool isCheck_Input;
        static bool preventContinuityInput;

        static float buttonDownTime;
        static float timer;

        /// <summary>
        /// Simultaneous input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool SingleInputKeyDown(KeyCode key)
        {
            if (Input.anyKeyDown == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetKeyDown(key))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continuity input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <param name="intervalSeconds"></param>
        /// <returns></returns>
        public static bool Interval_InputKeydown(KeyCode key, float intervalSeconds)
        {
            timer = Time.time;

            if (Input.GetKeyDown(key) && timer - buttonDownTime >= intervalSeconds)
            {
                if (preventContinuityInput == false)
                {
                    preventContinuityInput = true;
                    buttonDownTime = Time.time;
                    return true;
                }
                else if (preventContinuityInput)
                {
                    preventContinuityInput = false;
                    buttonDownTime = Time.time;
                    return true;
                }
            }

            return false;
        }
    }

}
