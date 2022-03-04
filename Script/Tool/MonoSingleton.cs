using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terric.Tool
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static bool _isQuit;
        private static readonly object _instanceLock = new object();

        public static T Instance
        {
            get
            {
                if (_isQuit)
                {
                    _instance = null;
                    return _instance;
                }
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();
                        if (_instance == null)
                        {
                            var go = new GameObject(typeof(T).Name);
                            _instance = go.AddComponent<T>();
                            DontDestroyOnLoad(go);
                        }
                    }

                    return _instance;
                }
            }
        }

        private void Awake()
        {
            _isQuit = false;
            if (this != _instance)
            {
                DestroyImmediate(gameObject);
                return;
            }
            Init();
        }

        private void OnDestroy()
        {
            _isQuit = true;
        }
        /// <summary>
        /// 初始化函数，替代Awake功能
        /// </summary>
        protected virtual void Init() { }
    }
}