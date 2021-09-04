using UnityEngine;

namespace Arkanoid
{
    internal sealed class BlockView : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}