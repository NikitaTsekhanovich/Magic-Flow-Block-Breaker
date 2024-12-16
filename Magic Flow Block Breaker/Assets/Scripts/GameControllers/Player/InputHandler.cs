using GameControllers.GameLogic;
using UnityEngine;

namespace GameControllers.Player
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] PlayerMovement _playerMovement;
        
        private void Update()
        {
            if (GameOverDisplay.IsGameOver) return;
            
            if (Input.GetMouseButton(0))
            {
                var mouseScreenPosition = Input.mousePosition;
                var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
                var hits = Physics2D.RaycastAll(mouseWorldPosition, Vector2.zero);

                foreach (var hit in hits)
                {
                    if (hit.collider != null && hit.collider.CompareTag("ClickField"))
                    {
                        _playerMovement.ChangeDirection(mouseWorldPosition.x);
                    }
                }
            }
        }
    }
}
