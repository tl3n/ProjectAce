using UnityEngine;

namespace RoomGeneration
{
    public abstract class EnemiesCreator : MonoBehaviour
    {
        public abstract Enemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }
}