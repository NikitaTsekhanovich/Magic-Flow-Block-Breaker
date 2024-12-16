using UnityEngine;

namespace GameControllers.Player
{
    public class TailMovement : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _tailImage;
        [SerializeField] private Rigidbody2D _rigidbody;
        private Transform _head;
        private float _destroyDuration;
        private bool _isStartedDestroy;
        private const float Speed = 20f;
        private const float DestroyTime = 3f;

        public void Init(Transform head, Sprite tailSprite)
        {
            _head = head;
            _tailImage.sprite = tailSprite;
        }

        public void StartDestroy()
        {
            _isStartedDestroy = true;
            _rigidbody.gravityScale = 0.6f;
        }
        
        private void Update()
        {
            if (_isStartedDestroy)
            {
                _destroyDuration += Time.deltaTime;
                
                if (_destroyDuration >= DestroyTime)
                    Destroy(gameObject);
            }
            else
            {
                var headPositionX = new Vector3(_head.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, headPositionX, Time.deltaTime * Speed);
            }
        }
    }
}
