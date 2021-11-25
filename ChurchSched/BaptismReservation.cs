using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationNameSpace
{
    class BaptismReservation:Reservation
    {
        private string candidate;
        public BaptismReservation(long id, string type, string name, string contactNumber, string emailAddress,
            string homeAddress,string candidate, DateTime date, DateTime time):base(id,type,name,contactNumber,
                emailAddress,homeAddress,date,time)
        {
            this.candidate = candidate;
        }
        public string newCandidate
        {
            get { return this.candidate; }
            set { this.candidate = value; }
        }
    }
}
