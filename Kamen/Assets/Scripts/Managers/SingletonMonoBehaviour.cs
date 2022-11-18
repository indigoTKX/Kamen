using UnityEngine;

namespace TKX1.Gameplay
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();
            }
            else
            {
                Destroy(gameObject);
            }
            
            OnAwake();
        }

        protected virtual void OnAwake() {}
    }
}