using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Vector2 target;
    private bool isRespawning = false;

    void Start()
    {
        target = pointB.position; // La scie démarre en direction de B
    }

    void Update()
    {
        if (!isRespawning)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target) < 0.1f)
            {
                isRespawning = true;
                Debug.Log("🔄 Changement de direction...");
                Invoke(nameof(SwitchTarget), 1f); // Attendre 1 seconde avant de repartir
            }
        }
    }

    void SwitchTarget()
    {
        target = (target == (Vector2)pointB.position) ? pointA.position : pointB.position;
        isRespawning = false;
    }
}