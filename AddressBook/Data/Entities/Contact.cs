﻿namespace AddressBook.Data.Entities
{
    public class Contact:EntityBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
