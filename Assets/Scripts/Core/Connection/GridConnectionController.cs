using System;
using System.Collections.Generic;
using Core.Selection;
using Core.Selection.Base;
using Core.Selection.Drag;
using UnityEngine;
using Zenject;

namespace Core.Connection
{
    [RequireComponent(typeof(Connectable))]
    public class GridConnectionController : MonoBehaviour
    {
        private Dictionary<Vector2Int, Connector> connectors = new();
        [SerializeField] private SpriteRenderer highlightPositionSprite;

        [Inject]
        public void Initialize(ObjectSelectionManager objectSelectionManager,
            ObjectDraggingManager objectDraggingManager)
        {
            objectSelectionManager.OnDeselected += obj =>
            {
                if (!obj.TryGetComponent(out Connectable connectable))
                    return;

                var position = obj.transform.position - transform.position;

                TryConnect(new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)), connectable);

                HideHighliteSprite();
            };

            objectDraggingManager.OnDragged += draggable =>
            {
                if (!draggable.TryGetComponent(out Connectable connectable))
                    return;

                var position = draggable.transform.position - transform.position;

                TryHighlightPosition(new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)));
            };

            var connector = new Connector();
            var connectable = GetComponent<Connectable>();
            connectors.Add(Vector2Int.zero, connector);
            connector.Connect(connectable);
            connectable.Connect(transform, Vector2Int.zero);
            CreateConnectorsAround(Vector2Int.zero);
        }

        private void HideHighliteSprite()
        {
            highlightPositionSprite.gameObject.SetActive(false);
        }

        private void TryHighlightPosition(Vector2Int position)
        {
            if (!connectors.TryGetValue(position, out Connector connector) || connector.HasConnection)
            {
                HideHighliteSprite();
                return;
            }

            highlightPositionSprite.gameObject.SetActive(true);

            highlightPositionSprite.transform.localPosition = new Vector3(position.x, position.y, 0);
        }

        public void TryConnect(Vector2Int position, Connectable connectable)
        {
            Debug.Log("try connect to " + position + " position");
            if (connectable.Connected)
            {
                Debug.Log("connectable already has connection");
                return;
            }

            if (!CheckNearConnectables(position))
            {
                Debug.Log("there is no near connectables");
                return;
            }

            if (!connectors.TryGetValue(position, out Connector connector))
            {
                Debug.Log("there is no connector at such position");
                return;
            }

            if (connector.HasConnection)
            {
                Debug.Log("connector already has connection");
                return;
            }

            connector.Connect(connectable);
            connectable.Connect(transform, position);

            connectable.GetComponent<Draggable>().SetDragEnabled(false);

            CreateConnectorsAround(position);
            Debug.Log("connected");
        }

        private bool CheckNearConnectables(Vector2Int position)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    var currentPosition = new Vector2Int(position.x + x, position.y + y);

                    if (!connectors.TryGetValue(currentPosition, out Connector currentConnector))
                        continue;

                    if (currentConnector.HasConnection)
                        return true;
                }
            }

            return false;
        }

        private void CreateConnectorsAround(Vector2Int position)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (Math.Abs(x) == 1 && Math.Abs(y) == 1)
                        continue;

                    var currentPosition = new Vector2Int(position.x + x, position.y + y);

                    connectors.TryAdd(currentPosition, new Connector());
                }
            }
        }
    }
}