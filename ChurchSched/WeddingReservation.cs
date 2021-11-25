using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchNameSpace
{
    class WeddingReservation:Reservation
    {
        private string groomName, brideName;
        public WeddingReservation(long id, string type, string name, string contactNumber, string emailAddress,
            string homeAddress, string groomName, string brideName, DateTime date, DateTime time) : base(id, type, name, contactNumber,
                emailAddress, homeAddress, date, time)
        {
            this.groomName = groomName;
            this.brideName = brideName;
        }
        public string newGroom
        {
            get { return this.groomName; }
            set { this.groomName = value; }
        }
        public string newBride
        {
            get { return this.brideName; }
            set { this.brideName = value; }
        }
    }
}
