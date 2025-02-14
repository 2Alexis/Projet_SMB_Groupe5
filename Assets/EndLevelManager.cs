using UnityEngine;

public class EndLevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifiez si le joueur touche l'objet "Rose"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Complete! Arrêt du jeu...");
            StopGame(); // Arrête le jeu
        }
    }

    private void StopGame()
    {
        // Arrête le jeu
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Arrête le jeu dans l'éditeur Unity
        #else
            Application.Quit(); // Ferme l'application dans une build
        #endif
    }
}