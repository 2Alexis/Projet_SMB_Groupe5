using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableTilemap : MonoBehaviour
{
    public Tilemap tilemap; // Référence au Tilemap
    public TileBase destructibleTile; // Tile spécifique à détruire

    void Update()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        // Vérifie si la tile sous le joueur est une tile destructible
        if (tilemap.GetTile(cellPosition) == destructibleTile)
        {
            Debug.Log("Tile destructible détectée et supprimée !");
            tilemap.SetTile(cellPosition, null); // Supprime la tile
        }
    }
}