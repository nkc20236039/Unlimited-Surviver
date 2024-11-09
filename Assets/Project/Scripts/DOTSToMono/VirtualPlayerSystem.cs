using DOTS;
using Unity.Entities;

namespace DOTStoMono
{
    [UpdateAfter(typeof(ActionUpdateGroup))]
    public partial struct VirtualPlayerSystem : ISystem
    {
        void ISystem.OnCreate(ref Unity.Entities.SystemState state)
        {
            state.RequireForUpdate<VirtualPlayerManagedComponent>();
            state.RequireForUpdate<PlayerComponent>();
        }

        void ISystem.OnUpdate(ref Unity.Entities.SystemState state)
        {
            // MonoBehaviour���̃v���C���[���擾
            var virtualPlayer = SystemAPI.ManagedAPI
                .GetSingleton<VirtualPlayerManagedComponent>();

            // DOTS���̃v���C���[���擾
            var player = SystemAPI.GetSingleton<PlayerComponent>();

            // �ʒu�𓯊�
            virtualPlayer.VirtualPlayerTransform.position = player.Position;
        }
    }
}