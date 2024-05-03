using UnityEngine;

namespace RoomGeneration
{
    public abstract class EnemiesCreator<T> : MonoBehaviour
    {
        public abstract T GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class MelleEnemiesCreator : EnemiesCreator<MelleEnemy>
    {
        public abstract override MelleEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class RangerEnemiesCreator : EnemiesCreator<RangerEnemy>
    {
        public abstract override RangerEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class SummonerEnemiesCreator : EnemiesCreator<SummonerEnemy>
    {
        public abstract override SummonerEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }

    public abstract class BossEnemiesCreator : EnemiesCreator<BossEnemy>
    {
        public abstract override BossEnemy GetEnemy(Transform room, Vector2 scenePosition, int xPos, int yPos);
    }
}