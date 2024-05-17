using System;
using Core.Blocks;
using Core.Pooling;
using Core.Pooling.Base;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : Poolable
{
    private int _damage;

    public void Initialize(int damage, int ignoreLayer)
    {
        _damage = damage;
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask(LayerMask.LayerToName(ignoreLayer));
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out BlockComponent block))
            return;
        
        block.Damage(_damage);
        
        PoolManager.Instance.Put(this);
        Deactivate();
    }
}