using UnityEngine;

namespace GameControllers.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private Rigidbody2D _rigidbody;
        private const float _speed = 50f;

        public void ChangeDirection(float mouseX)
        {
            var targetX = Mathf.Lerp(_headTransform.position.x, mouseX, _speed * Time.deltaTime);
            _rigidbody.MovePosition(new Vector2(targetX, _headTransform.position.y));
        }
    }
}
