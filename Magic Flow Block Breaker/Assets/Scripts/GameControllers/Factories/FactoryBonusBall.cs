using GameControllers.GameEntities.BonusBalls;
using GameControllers.LocationControllers.PartControllers;

namespace GameControllers.Factories
{
    public class FactoryBonusBall : Factory<BonusBallInitializer>
    {
        private void OnEnable()
        {
            Part.OnGetBonusBall += GetGameEntity;
        }

        private void OnDisable()
        {
            Part.OnGetBonusBall -= GetGameEntity;
        }
    }
}
