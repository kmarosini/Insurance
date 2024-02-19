using Dapper;
using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using System;
using System.Linq;

namespace PartnerWeb.Services
{
    public class PartnerService : IPartnerService
    {
        public void CreatePartner(Partner partner)
        {
            if (!Partner.IsValid(partner))
            {
                throw new Exception("Provided content is not valid.");
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@FirstName", partner.FirstName);
                param.Add("@LastName", partner.LastName);
                param.Add("@Address", partner.Address);
                param.Add("@PartnerNumber", Convert.ToDecimal(partner.PartnerNumber));
                param.Add("@CroatianPIN", partner.CroatianPIN);
                param.Add("@PartnerTypeId", partner.PartnerTypeId);
                param.Add("@CreateByUser", partner.CreateByUser);
                param.Add("@IsForegin", partner.IsForeign.HasValue ? partner.IsForeign : false);
                param.Add("@ExternalCode", partner.ExternalCode);
                param.Add("@Gender", partner.Gender);
                DapperORM.ExecuteWithoutReturn("PartnerAdd", param);
            } 
        }

        public void DeletePartner(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            DapperORM.ExecuteWithoutReturn("DeletePartnerById", param);
        }

        public Partner GetPartnerById(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return DapperORM.ReturnList<Partner>("GetPartnerById", param).FirstOrDefault();
        }

        public void UpdatePartner(Partner partner)
        {
            if (!Partner.IsValid(partner))
            {
                throw new Exception("Provided content is not valid.");
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", partner.Id);
                param.Add("@FirstName", partner.FirstName);
                param.Add("@LastName", partner.LastName);
                param.Add("@Address", partner.Address);
                param.Add("@PartnerNumber", Convert.ToInt64(partner.PartnerNumber), System.Data.DbType.Int64);
                param.Add("@CroatianPIN", partner.CroatianPIN);
                param.Add("@PartnerTypeId", partner.PartnerTypeId);
                param.Add("@CreateByUser", partner.CreateByUser);
                param.Add("@IsForegin", partner.IsForeign.HasValue ? partner.IsForeign : false);
                param.Add("@ExternalCode", partner.ExternalCode);
                param.Add("@Gender", partner.Gender);
                DapperORM.ExecuteWithoutReturn("PartnerUpdate", param);
            }  
        }
    }
}