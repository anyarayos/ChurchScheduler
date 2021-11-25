using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationNameSpace
{
    class MassReservation:Reservation
    {
        private string purpose;
        public MassReservation(long id, string type, string name, string contactNumber, string emailAddress,
            string homeAddress, string purpose, DateTime date, DateTime time) : base(id, type, name, contactNumber,
                emailAddress, homeAddress, date, time)
        {
            this.purpose = purpose;
        }
        public string newPurpose
        {
            get { return this.purpose; }
            set { this.purpose = value; }
        }
    }
}
