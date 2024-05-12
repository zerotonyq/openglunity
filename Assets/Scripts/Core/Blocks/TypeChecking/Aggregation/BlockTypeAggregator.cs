using Core.Connection.Aggregation;
using Core.Connection.Enum;
using UnityEngine;

namespace Core.Blocks.TypeChecking.Aggregation
{
    [RequireComponent(typeof(ConnectorsAggregator))]
    public class BlockTypeAggregator : MonoBehaviour
    {
        private ConnectorsAggregator _connectorsAggregator;
     
        private void Awake() => _connectorsAggregator = GetComponent<ConnectorsAggregator>();

        
        public bool CheckConnectionAndTypes(BlockType exceptiontype)
        {
            if (!_connectorsAggregator.CheckConnections())
                return false;
            
            BlockType mainType = BlockType.None;
            
            for (int i = 0; i < _connectorsAggregator.Connectors.Count; i++)
            {
                var current = 
                    _connectorsAggregator.Connectors[i].CurrentConnectable.GetComponent<BlockComponent>().BlockType;
                
                if (current != exceptiontype)
                    mainType = current;

                if (mainType != current)
                    return false;
            }

            return true;
        }
    }
}