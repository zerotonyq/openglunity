using System;
using Core.Blocks.Types;
using Core.Connection;
using Core.Selection;
using Core.Selection.Base;
using UnityEngine;
using Zenject;

namespace Core.Blocks
{
    [RequireComponent(typeof(GridConnectionController))]
    public class BlockMergeController : MonoBehaviour
    {
        private GridConnectionController _gridConnectionController;

        [Inject]
        private void Initialize(ObjectSelectionManager objectSelectionManager)
        {
            _gridConnectionController = GetComponent<GridConnectionController>();
            objectSelectionManager.OnSelected += o =>
            {
                if (!o.TryGetComponent(out Connectable connectable))
                    return;

                if (!connectable.Connected)
                    return;

                var position = connectable.transform.position;
                var connectableIntPosition = new Vector2Int(Mathf.RoundToInt(position.x),
                    Mathf.RoundToInt(position.y));
                var l = _gridConnectionController.GetNearConnectors(connectableIntPosition);

                foreach (var pair in l)
                {
                    Debug.Log(pair.Key + " position " + pair.Value.HasConnection + " has connection");
                    _gridConnectionController.DeleteConnectableAndMove(pair.Key, connectableIntPosition);
                }
            };
        }

        public void TryMerge()
        {
            Debug.Log("try merge");
        }
    }
}