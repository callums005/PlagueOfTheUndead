using UnityEngine;
using UnityEngine.InputSystem;

public class TestingScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject arrow;

    private void Update()
    {
        if (enemy == null)
            return;

        if (InputSystem.GetDevice<Keyboard>().kKey.wasPressedThisFrame)
        {
            Instantiate(arrow);
            //a.transform.Rotate(0, GameObject.FindGameObjectWithTag("Player").transform.rotation.y, 0);
        }
    }
}
