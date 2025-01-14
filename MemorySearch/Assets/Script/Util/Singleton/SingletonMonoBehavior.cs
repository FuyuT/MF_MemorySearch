﻿using UnityEngine;
using System;

namespace MyUtil
{
    public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour,new()
    {
        /*******************************
        * private
        *******************************/
        static T instance;

        private void Awake()
        {
            Instance();
            if(this != instance)
            {
                Destroy(this);
                return;
            }
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
        /*******************************
        * public
        *******************************/
        public static T Instance()
        {
            if (!instance)
            {
                Type t = typeof(T);
                instance = (T)FindObjectOfType(t);
                if (!instance)
                {
                    Debug.LogError(t + " is nothing.");
                }
            }
            return instance;
        }
        /*******************************
        * protected
        *******************************/
        protected abstract bool dontDestroyOnLoad { get; }
    }
}