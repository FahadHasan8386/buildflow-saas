using Build_flow_Saas.api.Models.Entities;

namespace Build_flow_Saas.api.Interfaces.IRepository
{
    public interface INotificationRepository
    {
        Task<Notification?> GetByIdAsync(long notificationId, long memberId);
        Task<IEnumerable<Notification>> GetByMemberIdAsync(long memberId);

        Task<long> CreateAsync(Notification notification);
        Task<bool> MarkAsReadAsync(long notificationId, long memberId);
        Task<bool> MarkAllAsReadAsync(long memberId);
    }
}
