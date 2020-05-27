using System.Collections;
using UnityEngine;

namespace Interactables
{
    public class FallingFloor : MonoBehaviour
    {
        [SerializeField] private float delayToFall;
        [SerializeField] private float delayToAppearAgain;
        [SerializeField] private BoxCollider2D topCollider;
        [SerializeField] private BoxCollider2D bottomCollider;
        
        private Rigidbody2D _floorRb;
        private SpriteRenderer _spriteRenderer;
        private Vector2 _originalPosition;
        private bool _falling;
        private bool _finishFading;
        private void Awake()
        {
            _originalPosition = transform.position;
            _floorRb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private IEnumerator FallFloor(float delay)
        {
            _falling = true;
            yield return new WaitForSeconds(delay);
            bottomCollider.enabled = false;
            topCollider.enabled = false;
            SetRigidBodyProperties(false);
            StartCoroutine(FadeEffect(true));
            while (!_finishFading)
            {
               yield return new WaitForSeconds(1);
            }                
            StartCoroutine(EnableFloor(delayToAppearAgain));
        }
        private IEnumerator EnableFloor(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetRigidBodyProperties(true);
            transform.position = _originalPosition;
            StartCoroutine(FadeEffect(false));

            while (!_finishFading)
            {
               yield return new WaitForSeconds(1);
            }                
            bottomCollider.enabled = true;
            topCollider.enabled = true;
            _falling = false;
        }

        private IEnumerator FadeEffect(bool fadeOut)
        {
            _finishFading = false;
            var multiply = fadeOut ? -1 : 1;
            Color objectColor = _spriteRenderer.color;
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.2f);
                objectColor.a += 0.2f * multiply;
                _spriteRenderer.color = objectColor;
            }
            _finishFading = true;
        }

        private void SetRigidBodyProperties(bool enable)
        {
            _floorRb.bodyType = enable ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic;
            _floorRb.gravityScale = enable ?  0 : 0.3f;
            if (enable)
            {
                _floorRb.velocity = Vector2.zero;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_falling) return;
            if (other.transform.CompareTag($"Player"))
            {
                if (other.gameObject.GetComponent<Collider2D>().IsTouching(topCollider))
                {
                    StartCoroutine(FallFloor(delayToFall));
                }
            }
        }
    }
}