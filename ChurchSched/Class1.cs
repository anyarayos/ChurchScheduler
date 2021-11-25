using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchNameSpace
{
    class Reservation
    {
        private long id;
        string type, name, contactNumber, emailAddress, homeAddress;
        DateTime date, time;

        public void confirmReservation()
        {

        }
        public void editReservation()
        {

        }
        public void cancelReservation()
        {

        }

        public long newID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string newType
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string newName
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string newContact
        {
            get { return this.contactNumber; }
            set { this.contactNumber = value; }
        }
        public string newEmail
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }
        public string newAddress
        {
            get { return this.homeAddress; }
            set { this.homeAddress = value; }
        }
        public DateTime newDate
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public DateTime newTime
        {
            get { return this.time; }
            set { this.time = value; }
        }
    }
}
