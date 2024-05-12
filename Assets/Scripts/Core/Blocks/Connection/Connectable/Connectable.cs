using System;
using System.Linq;
using Core.Blocks;
using Core.Blocks.TypeChecking;
using Core.Connection.Aggregation;
using Core.Connection.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Connection
{
    [RequireComponent(typeof(Collider2D))]
    public class Connectable : MonoBehaviour
    {
        public bool IsConnected { get; private set; }

        private Collider2D _collider;
        public void Awake()
        {
            GetComponent<BlockComponent>().OnDragged += TryConnect;
            _collider = GetComponent<Collider2D>();
        }

        private void TryConnect()
        {

            if (IsConnected)
                return;
            
            var hits = new RaycastHit2D[1];

            if (Physics2D.CircleCastNonAlloc(transform.position, 0.1f, Vector2.zero, hits) == 0)
            {
                _collider.isTrigger = true;
            
                IsConnected = false;
                
                return;
            }

            if (!hits[0].collider.TryGetComponent(out Connector connector))
                return;

            if (GetComponent<ConnectorsAggregator>().Connectors.Contains(connector))
                return;
            
            Debug.Log("connected to " + connector.name);
            connector.Connect(this);
            
            _collider.isTrigger = false;
            GetComponent<BlockComponent>().BlockPositioning();

            IsConnected = true;
        }
    }
}