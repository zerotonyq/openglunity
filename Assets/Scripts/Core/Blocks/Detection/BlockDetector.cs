using System;
using System.Collections;
using Core.Blocks;
using UnityEngine;

namespace Core.Gears.Weapons.Base
{
    public class BlockDetector : MonoBehaviour
    {
        public Action<BlockComponent> OnBlockDetected;
        
        public float DetectionDeltaTime { get; private set; }

        public float DetectionRadius { get; private set; }

        private RaycastHit2D[] _detectedObjects;

        private Transform _transform;
        private int _enemyLayer;
        public void Initialize(float detectionDeltaTime, float detectionRadius, int enemyLayer,int maxDetectedObjects = 1)
        {
            _enemyLayer = enemyLayer;
            DetectionDeltaTime = detectionDeltaTime;
            DetectionRadius = detectionRadius;
            _detectedObjects = new RaycastHit2D[maxDetectedObjects];
            _transform = transform;
        }

        public void StartDetection() => StartCoroutine(DetectionCoroutine());

        public void StopDetection() => StopAllCoroutines();

        public IEnumerator DetectionCoroutine()
        {
            while (true)
            {
                if (Physics2D.CircleCastNonAlloc(_transform.position, DetectionRadius, Vector2.zero,
                        _detectedObjects,DetectionRadius, 1<<_enemyLayer) == 0)
                {
                    Debug.Log("no objects detected");
                    yield return null;
                }

                BlockComponent currentDetectedBlock = null;
                float minDistance = DetectionRadius;
                foreach (var detectedObject in _detectedObjects)
                {
                    if (!detectedObject.collider)
                        continue;
                    
                    if (!detectedObject.transform.TryGetComponent(out BlockComponent block))
                        continue;

                    if(!block.isConnected)
                        continue;

                    if (minDistance > (transform.position - block.transform.position).magnitude)
                    {
                        minDistance = (transform.position - block.transform.position).magnitude;
                        currentDetectedBlock = block;    
                    }
                    
                    
                }

                if (!currentDetectedBlock)
                {
                    Debug.Log("no blocksDetected");
                    yield return null;
                }
    
                OnBlockDetected?.Invoke(currentDetectedBlock);

                yield return new WaitForSeconds(DetectionDeltaTime);
            }
            
        }

        private void OnDisable() => StopAllCoroutines();
    }
}