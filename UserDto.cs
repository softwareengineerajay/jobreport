namespace ReportProject
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class ReportItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total => Price * Qty;
    }

    public class TempJobReturnTicketPrintDetails
    {

        public int UserId { get; set; }
        public string ASPXPage { get; set; }
        public string Address { get; set; }
        public int OrderNumber { get; set; }
        public string ShipDate { get; set; }
        public string ProjectId { get; set; }
        public string RigName { get; set; }
        public string Requisition { get; set; }
        public string CustomerReference { get; set; }
        public string LeaseOSCGNumber { get; set; }
        public string CustomerLocation { get; set; }
        public string AFE { get; set; }
        public string CustomerContact { get; set; }

        public string ShipTo { get; set; }
        public string BillTo { get; set; }
        public string ItemNumber { get; set; }
        public string SerialNumber { get; set; }

        public decimal SalesQuantity { get; set; }
        public string Unit { get; set; }
        public string DateCreated { get; set; }
        public string Attributes { get; set; }

    }
}