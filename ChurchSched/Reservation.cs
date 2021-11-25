using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationNameSpace
{
    class Reservation
    {
        private long id;
        private string type, name, contactNumber, emailAddress, homeAddress;
        private DateTime date, time;
        public Reservation() { }
        public Reservation(long id, string type, string name, string contactNumber, string emailAddress, 
            string homeAddress, DateTime date, DateTime time)
        {
            this.id = id;
            this.type = type;
            this.name = name;
            this.contactNumber = contactNumber;
            this.emailAddress = emailAddress;
            this.homeAddress = homeAddress;
            this.date = date;
            this.time = time;
        }
        public void confirmReservation()
        {
            //Do something
        }
        public void editReservation()
        {
            //Do something
        }
        public void cancelReservation()
        {
            //Do something
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
