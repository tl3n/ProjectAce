namespace DungeonGeneration
{
    /// <summary>
    /// Enum to represent sides in the matrix layout
    /// </summary>
    public enum Side
    {
        Top,
        Right,
        Bottom,
        Left
    }

    /// <summary>
    /// Type of the room
    /// </summary>
    public enum RoomType
    {
        Start = 1,
        EnemyEasy = 2,
        EnemyMedium = 3,
        EnemyHard = 4,
        Treasure = 5,
        Boss = 6
    }
}
