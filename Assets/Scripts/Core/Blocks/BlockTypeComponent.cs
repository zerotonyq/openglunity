using Core.Blocks.Types;
using Core.Selection.Base;
using UnityEngine;

namespace Core.Blocks
{
    [RequireComponent(typeof(Selectable))]
    public class BlockTypeComponent : MonoBehaviour
    {
        [SerializeField] private BlockType blockType;

        public BlockType BlockType => blockType;

        
    }
}