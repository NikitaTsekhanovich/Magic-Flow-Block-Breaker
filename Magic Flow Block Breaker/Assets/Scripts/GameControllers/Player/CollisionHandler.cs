using GameControllers.GameEntities.Blocks;
using GameControllers.GameEntities.BonusBalls;
using UnityEngine;

namespace GameControllers.Player
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private TailHandler _tailHandler;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private AudioSource _destroyBlockSound;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BonusBallInitializer>(out var bonusBallInitializer))
            {
                _tailHandler.IncreaseTail(bonusBallInitializer, bonusBallInitializer.Amount);
            }
            else if (collision.TryGetComponent<BlockInitializer>(out var blockInitializer))
            {
                _tailHandler.DecreaseTail(blockInitializer.Amount);
                blockInitializer.DestroyedByPlayer();
                _destroyBlockSound.Play();
            }
        }
    }
}
