using System.Collections;
using UnityEngine;

namespace Lesson1 {

    public class CoroutineExample : MonoBehaviour
    {
        private SpriteRenderer renderer;

        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            //StartCoroutine(PrintOverTime());
            //StartCoroutine(MoveUp(3, Vector3.up));
            //StartCoroutine(MoveAround());
            //StartCoroutine(PrintAndDestroy());
            //Coroutine coroutine = StartCoroutine(PrintMessage());
            //StopCoroutine(coroutine);
            StartCoroutine(GenericAnimation(new Vector3(3, -2, 0), Color.green, 10));
        }

        IEnumerator MoveUp(float time, Vector3 direction)
        {
            while (transform.position.y < 10)
            {
                yield return new WaitForSeconds(time);
                transform.position += direction;
            }
        }

        IEnumerator PrintOverTime()
        {
            Debug.Log($"Message was printed instantly");
            yield return new WaitForSeconds(1.0f);
            Debug.Log($"Message was printed after 1 second");
        }

        IEnumerator MoveAround()
        {
            transform.position += Vector3.up;
            yield return new WaitForSeconds(1);
            transform.position += Vector3.left;
            yield return new WaitForSeconds(1);
            transform.position += Vector3.down;
            yield return new WaitForSeconds(1);
            transform.position += Vector3.right;
            yield return new WaitForSeconds(1);
        }

        IEnumerator PrintAndDestroy()
        {
            int i = 10;
            while (true)
            {
                Debug.Log($"{i} seconds left");
                i--;
                if (i == 1) enabled = false;
                if (i == 0) Destroy(gameObject);
                yield return new WaitForSeconds(1.0f);
            }
        }

        IEnumerator PrintMessage()
        {
            while (true)
            {
                Debug.Log("Test message!");
                yield return null;
            }
        }

        IEnumerator GenericAnimation(Vector3 targetPosition, Color targetColor, float duration)
        {
            Vector3 startPosition = transform.position;
            Color startColor = renderer.color;
            float progress = 0;

            while (progress <= 1)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
                renderer.color = Color.Lerp(startColor, targetColor, progress);
                progress += Time.deltaTime / duration;
                yield return null;
            }
            transform.position = targetPosition;
            renderer.color = targetColor;
        }
    }
}
