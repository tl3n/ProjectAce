using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemiesCreator : MonoBehaviour
{
    public abstract Enemy Create(Transform room, Vector2 scenePosition, int xPos, int yPos);
}
