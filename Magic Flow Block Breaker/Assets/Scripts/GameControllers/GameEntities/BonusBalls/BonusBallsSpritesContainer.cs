using UnityEngine;
using Random = UnityEngine.Random;

namespace GameControllers.GameEntities.BonusBalls
{
    public class BonusBallsSpritesContainer : MonoBehaviour
    {
        [SerializeField] public SpritesSettings[] _bonusBallsSprites;

        private void OnEnable()
        {
            BonusBallInitializer.OnGetSprite += GetRandomSprite;
        }

        private void OnDestroy()
        {
            BonusBallInitializer.OnGetSprite -= GetRandomSprite;
        }

        public SpritesSettings GetRandomSprite()
        {
            var randomIndex = Random.Range(0, _bonusBallsSprites.Length);
            return _bonusBallsSprites[randomIndex];
        }
    }
}
