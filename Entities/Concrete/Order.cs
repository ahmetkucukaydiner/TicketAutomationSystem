using Core.Entitites.Abstract;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int JourneyId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int SeatNumber { get; set; }
        public bool Status { get; set; }
        public bool Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string GovId { get; set; }
        public string PassportNumber { get; set; }
        public int PNR { get; set; }
        public int CustomerId { get; set; }
        public decimal SalesPrice { get; set; }
        public int SalesBranchId { get; set; }
        public int SalesUserId { get; set; }
    }
}
