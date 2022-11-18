using System;
using UnityEngine;

namespace TKX1.Gameplay
{
    public class DestroyableEnvironment : MonoBehaviour
    {
        [SerializeField] private float _deletePosition = -2f;

        private Action<DestroyableEnvironment> _respawnAction = null;

        private void Update()
        {
            if (transform.position.z > _deletePosition) return;
            if (_respawnAction == null)
            {
                Destroy(gameObject);
            }
            else
            {
                _respawnAction(this);
            }
        }

        public void Initialize(Action<DestroyableEnvironment> onDestroy)
        {
            _respawnAction = onDestroy;
        }
    }
}