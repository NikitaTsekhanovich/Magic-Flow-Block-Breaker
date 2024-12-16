using GameControllers.GameEntities.Blocks;
using GameControllers.LocationControllers.PartControllers;

namespace GameControllers.Factories
{
    public class FactoryEmptyBlock : Factory<EmptyBlockInitializer>
    {
        private void OnEnable()
        {
            Part.OnGetEmptyBlock += GetGameEntity;
        }

        private void OnDisable()
        {
            Part.OnGetEmptyBlock -= GetGameEntity;
        }
    }
}
