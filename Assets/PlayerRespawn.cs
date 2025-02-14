using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position; // Sauvegarde la position initiale
    }

    public void Respawn()
    {
        Debug.Log("🔄 Respawn du joueur !");
        transform.position = respawnPoint;
    }

    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPoint = newPoint; // Changer le point de respawn (utile pour les checkpoints)
    }
}