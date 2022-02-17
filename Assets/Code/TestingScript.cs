using UnityEngine;
using UnityEngine.InputSystem;

public class TestingScript : MonoBehaviour
{
    public GameObject enemy;

    private void Update()
    {
        if (enemy == null)
            return;
    }
}
