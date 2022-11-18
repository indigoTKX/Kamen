using UnityEngine;

namespace TKX1.Gameplay
{
    public class DestroyableObject : MonoBehaviour
    {
        [SerializeField] private float _deletePosition = -12f;

        private void Update()
        {
            if (transform.position.z > _deletePosition) return;
            Destroy(gameObject);
        }
    }
}