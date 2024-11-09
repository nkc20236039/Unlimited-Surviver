using Unity.Entities;

namespace DOTS
{
    public struct EnemySpawnerComponent : IComponentData
    {
        public float SpawnRadius;   // 敵が召喚される半径
        public Entity Enemy;
        public float SpawnInterval; // 召喚する間隔

        public float SpawnTime;     // 次の召喚までの待ち時間
    }
}