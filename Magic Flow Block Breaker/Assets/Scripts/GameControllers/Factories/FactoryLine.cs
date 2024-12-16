using GameControllers.GameEntities.Lines;
using GameControllers.LocationControllers.PartControllers;

namespace GameControllers.Factories
{
    public class FactoryLine : Factory<LineInitializer>
    {
        private void OnEnable()
        {
            Part.OnGetLine += GetGameEntity;
        }

        private void OnDisable()
        {
            Part.OnGetLine -= GetGameEntity;
        }
    }
}
