using System;
using EcommerceMvc.Models;
using PetaPoco;

namespace EcommerceMvc.Pocos
{
    [ExplicitColumns]
    [TableName("Person")]
    [PrimaryKey("Id")]
    public class Person
    {
        [Column]
        public int Id { get; set; }

        [Column]
        public string FirstName { get; set; }

        [Column]
        public string LastName { get; set; }

        [Column]
        public string UserName { get; set; }

        [Column]
        public string EmailId { get; set; }

        [Column]
        public long Phone { get; set; }

        [Column]
        public string Password { get; set; }

        [Column]
        public DateTime CreateDate { get; set; }

        [Column]
        public string CreatedBy { get; set; }

        [Column]
        public string Salt { get; set; }

        public Address Address { get; set; }
    }
}