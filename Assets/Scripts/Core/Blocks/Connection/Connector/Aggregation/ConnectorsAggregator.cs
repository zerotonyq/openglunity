using System.Collections.Generic;
using Core.Connection.Enum;
using UnityEngine;

namespace Core.Connection.Aggregation
{
    
    public class ConnectorsAggregator : MonoBehaviour
    {
        [SerializeField] private List<Connector> connectors = new();

        public IReadOnlyList<Connector> Connectors => connectors;
        
        public bool CheckConnections()
        {
            for (int i = 0; i < connectors.Count; i++)
            {
                if (!connectors[i].HasConnection)
                    return false;
            }

            return true;
        }
        
        
    }
}