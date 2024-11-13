using Unity.Entities;
using Unity.Mathematics;

namespace DOTS
{
    public struct BulletComponent : IComponentData
    {
        public float Speed;     // 弾の速度
        public float Lifetime;  // 寿命

        public float Age;       // 存在した時間
    }
}