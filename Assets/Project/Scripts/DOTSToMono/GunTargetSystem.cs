using DOTS;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DOTStoMono
{
    [BurstCompile]
    public partial class GunTargetSystem : SystemBase
    {
        private TargetPointManagedSingleton targetPoint;

        protected override void OnCreate()
        {
            RequireForUpdate<TargetPointManagedSingleton>();
            RequireForUpdate<GunComponent>();
            RequireForUpdate<PlayerSingleton>();
        }

        protected override void OnUpdate()
        {
            if (targetPoint == null)
            {
                // ターゲット座標を管理するコンポーネントを取得
                targetPoint = SystemAPI.ManagedAPI
                    .GetSingleton<TargetPointManagedSingleton>();
            }

            var player = SystemAPI.GetSingletonEntity<PlayerSingleton>();
            var playerTransform = SystemAPI.GetComponent<LocalTransform>(player);

            foreach (var gun in SystemAPI.Query<RefRW<GunComponent>>())
            {
                float3 direction = targetPoint.Position - playerTransform.Position;

                // 結果を銃のターゲットに設定
                gun.ValueRW.TargetDirection = math.normalize(direction);
            }
        }
    }
}