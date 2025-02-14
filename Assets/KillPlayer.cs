using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("💀 Player Mort !");
            collision.gameObject.GetComponent<PlayerRespawn>().Respawn();
        }
    }
}