using PartnerWeb.Models;

namespace PartnerWeb.Services
{
    public interface IPartnerService
    {
        void CreatePartner(Partner partner);
        void UpdatePartner(Partner partner);
        void DeletePartner(int id);
        Partner GetPartnerById(int id);
    }
}
