using UnityEngine;

public class RotatingSaw : MonoBehaviour
{
    public float rotationSpeed = 300f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
