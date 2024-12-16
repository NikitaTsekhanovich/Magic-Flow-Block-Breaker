using GameControllers.LocationControllers;
using UnityEngine;

namespace GameControllers.GameLogic
{
    public class LocationGenerator : MonoBehaviour
    {
        [SerializeField] private LocationInitializer _locationPrefab;
        [SerializeField] private Transform _locationContainer;
        private float _speedLocation;
        private float _blockQuantityMultiplier;
        private int _locationCount;

        public void InitializeLocationsSettings(float speedLocation, float blockQuantityMultiplier)
        {
            _speedLocation = speedLocation;
            _blockQuantityMultiplier = blockQuantityMultiplier;
        }

        private void OnEnable()
        {
            LocationMovement.OnReachedBottom += SpawnLocation;
        }

        private void OnDisable()
        {
            LocationMovement.OnReachedBottom -= SpawnLocation;
        }

        private void SpawnLocation()
        {
            _locationCount++;
            var newLocation = Instantiate(_locationPrefab, _locationContainer);
            newLocation.Init(_locationCount, _speedLocation, _blockQuantityMultiplier);
        }
    }
}
