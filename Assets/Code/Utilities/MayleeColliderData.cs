using UnityEngine;

public class MayleeColliderData
{
    public bool HasCollided;
    public GameObject CollidedObject;

    public MayleeColliderData(bool hasCollided, GameObject collidedObject)
    {
        HasCollided = hasCollided;
        CollidedObject = collidedObject;
    }
}