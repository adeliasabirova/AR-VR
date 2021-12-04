using System;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(CharacterController))]
public abstract class Character : NetworkBehaviour
{
    protected Action OnUpdateAction { get; set; }
    protected abstract FireAction _fireAction { get; set; }

    [SyncVar] protected Vector3 _serverPosition;
    [SyncVar] protected Quaternion _serverRotationX;
    [SyncVar] protected Quaternion _serverRotationY;

    protected virtual void Initiate()
    {
        OnUpdateAction += Movement;
    }

    private void Update()
    {
        OnUpdate();
    }

    private void OnUpdate()
    {
        OnUpdateAction?.Invoke();
    }

    [Command]
    protected void CmdUpdatePosition(Vector3 position)
    {
        _serverPosition = position;
    }

    [Command]
    protected void CmdUpdateRotation(Quaternion rotationY, Quaternion rotationX)
    {
        _serverRotationX = rotationX;
        _serverRotationY = rotationY;
    }


    public abstract void Movement();
}
