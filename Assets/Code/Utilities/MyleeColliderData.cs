using UnityEngine;

public class MyleeColliderData
{
    public bool HasCollided;
    public GameObject CollidedObject;

    public MyleeColliderData(bool hasCollided, GameObject collidedObject)
    {
        HasCollided = hasCollided;
        CollidedObject = collidedObject;
    }
}