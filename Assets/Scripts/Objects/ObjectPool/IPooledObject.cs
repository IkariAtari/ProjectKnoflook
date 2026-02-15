using UnityEngine;

public interface IPooledObject
{
    IManagedPool ManagedPool { get; set; }
}
