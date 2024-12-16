using UnityEngine;

namespace GameControllers.GameEntities.Blocks
{
    public class BlockSpritesContainer : MonoBehaviour
    {
        [SerializeField] public SpritesSettings[] _blocksSprites;

        private void OnEnable()
        {
            BlockInitializer.OnGetSprite += GetRandomSprite;
        }

        private void OnDestroy()
        {
            BlockInitializer.OnGetSprite -= GetRandomSprite;
        }

        public SpritesSettings GetRandomSprite()
        {
            var randomIndex = Random.Range(0, _blocksSprites.Length);
            return _blocksSprites[randomIndex];
        }
    }
}
