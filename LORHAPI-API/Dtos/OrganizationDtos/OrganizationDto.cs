namespace LORHAPI_API.Dtos.OrganizationDtos
{
    public record OrganizationDto
    {
        public int IdOrganization { get; set; }

        public string OrgName { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public string ZIP { get; set; }

        public string City { get; set; }

    }
}
