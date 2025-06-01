using LeadManagement.Application.DTOs;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Application.Mappers
{
    public static class LeadMapper
    {
        public static LeadDTO MapToLeadDTO(this Lead lead)
        {
            return new LeadDTO
            {
                Id = lead.Id,
                FirstName = lead.Contact.FirstName,
                FullName = lead.Contact.FullName,
                Phone = lead.Contact.Phone,
                Email = lead.Contact.Email,
                Suburb = lead.Suburb,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
                DateCreated = lead.DateCreated,
                Status = Enum.GetName<EnLeadStatus>(lead.Status)
            };
        }

        public static IEnumerable<LeadDTO> MapToLeadDTO(this IEnumerable<Lead> leads) => leads.Select(lead => lead.MapToLeadDTO()).ToList();
    }
}
