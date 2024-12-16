using GameControllers.GameEntities.Blocks;
using GameControllers.LocationControllers.PartControllers;

namespace GameControllers.Factories
{
    public class FactoryBlock : Factory<BlockInitializer>
    {
        private void OnEnable()
        {
            Part.OnGetBlock += GetGameEntity;
        }

        private void OnDisable()
        {
            Part.OnGetBlock -= GetGameEntity;
        }
    }
}
