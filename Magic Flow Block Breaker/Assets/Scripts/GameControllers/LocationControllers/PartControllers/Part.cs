using System;
using System.Collections;
using GameControllers.GameEntities;
using GridExtension;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameControllers.LocationControllers.PartControllers
{
    public class Part : MonoBehaviour
    {
        [SerializeField] private PartType _partType;
        private FlexibleGridLayout _gridLayout;
        private float _blockQuantityMultiplier;

        public static Action<Transform, int, int> OnGetBlock;
        public static Action<Transform, int, int> OnGetEmptyBlock;
        public static Action<Transform, int, int> OnGetBonusBall;
        public static Action<Transform, int, int> OnGetLine;

        private void Awake()
        {
            _gridLayout = GetComponent<FlexibleGridLayout>();
        }

        public void Init(int indexLocation, float blockQuantityMultiplier)
        {
            _blockQuantityMultiplier = blockQuantityMultiplier;
            SpawnGameEntities(indexLocation);
            StartCoroutine(WaitEndFrame());
        }

        private void SpawnGameEntities(int indexLocation)
        {
            var partPattern = PartsPatternsDataContainer.DictPartsPatternsData[_partType];
            var randomIndex = Random.Range(0, partPattern.Count);

            for (var i = 0; i < _gridLayout.columns; i++)
            {
                for (var j = 0; j < _gridLayout.rows; j++)
                {
                    var blockPrototype = partPattern[randomIndex].BlocksOnGameField.Rows[i].RowBlocks[j];
                    
                    if (blockPrototype.Type == GameEntitiesType.Empty)
                    {
                        OnGetEmptyBlock.Invoke(transform, indexLocation, blockPrototype.AmountEntities);
                    }
                    else if (blockPrototype.Type == GameEntitiesType.Block)
                    {
                        OnGetBlock.Invoke(transform, indexLocation, (int)(blockPrototype.AmountEntities * _blockQuantityMultiplier));
                    }
                    else if (blockPrototype.Type == GameEntitiesType.Line)
                    {
                        OnGetLine.Invoke(transform, indexLocation, blockPrototype.AmountEntities);
                    }
                    else if (blockPrototype.Type == GameEntitiesType.BonusBall)
                    {
                        OnGetBonusBall.Invoke(transform, indexLocation, (int)(blockPrototype.AmountEntities * _blockQuantityMultiplier));
                    }
                }
            }
        }

        private IEnumerator WaitEndFrame()
        {
            yield return new WaitForEndOfFrame();
            _gridLayout.enabled = false;
        }
    }
}
