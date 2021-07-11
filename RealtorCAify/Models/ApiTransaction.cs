using System;

namespace RealtorCAify.Models
{
    public class ApiTransaction
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Resource { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}