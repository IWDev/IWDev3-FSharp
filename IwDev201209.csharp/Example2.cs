using System;

namespace IwDev201209.Example2
{
    // ==============================
    // Version 1
    // ==============================
    public class ContactInfo
    {
        public string First { get; set; }
        public string MiddleInitial { get; set; }
        public string Last { get; set; }

        public string EmailAddress { get; set; }
        public bool EmailIsValid { get; set; }
        public bool EmailIsVerified { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        // check the Royal Mail PAF file
        public bool AddressIsValid { get; set; }

    }


    /*

    Requirements
     * Contact MUST have first and last, but middle is optional
     * Must have a email or address or both, but not neither.
     * AddressIsValid must be updated using a third party service when the address is changed.
      
    */




















    // ==============================
    // Version 2
    // ==============================

    public class NameInfo
    {
        private string _first;
        public string First
        {
            get { return _first; }
            set
            {
                if (value == null) { throw new ArgumentException("First"); }
                _first = value;
            }
        }

        public string MiddleInitial { get; set; }

        private string _last;
        public string Last
        {
            get { return _last; }
            set
            {
                if (value == null) { throw new ArgumentException("Last"); }
                _last = value;
            }
        }
    }

    public class EmailInfo
    {
        public string EmailAddress { get; set; }
        public bool EmailIsValid { get; set; }
        public bool EmailIsVerified { get; set; }
    }

    public class AddressInfo
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }

        // check the Royal Mail PAF file
        public bool AddressIsValid { get; set; }
    }

    public class ContactInfo2
    {
        public NameInfo Name { get; set; }
        public EmailInfo EmailInfo { get; set; }
        public AddressInfo AddressInfo { get; set; }
    }




























    // ==============================
    // Version 3
    // ==============================

    public class NameInfo3
    {
        // ensure a valid object is created and thereafter immutable
        public NameInfo3(string first, string middle, string last)
        {
            if (first == null) { throw new ArgumentException("first"); }
            if (last == null) { throw new ArgumentException("last"); }

            First = first;
            Middle = middle;
            Last = last;
        }

        public NameInfo3(string first, string last)
            : this(first, null, last)
        {
        }


        public string First { get; private set; }
        public string Middle { get; private set; }
        public string Last { get; private set; }
    }




    public class AddressInfo3
    {
        public AddressInfo3(string address1, string address2, string town, string postCode)
        {
            Address1 = address1;
            Address2 = address2;
            Town = town;
            PostCode = postCode;
        }

        public string Address1 { get; private set; }
        public string Address2 { get; private set; }
        public string Town { get; private set; }
        public string PostCode { get; private set; }

        public bool AddressIsValid { get; set; }
    }

    public class ContactInfo3
    {
        public NameInfo Name { get; set; }
        public EmailInfo EmailInfo { get; set; }

        private AddressInfo3 _addressInfo;
        public AddressInfo3 AddressInfo
        {
            get { return _addressInfo; }
            set
            {
                _addressInfo = value;
                // call validation function
            }
        }







        /*

New requirement
 * send a message to email if they have one, otherwise send to the postal address
  
*/
















        // ==============================
        // Case processing
        // ==============================
        
        public void SendMessage()
        {
            if (EmailInfo != null)
            {
                Console.WriteLine("sending message to email {0}", EmailInfo.EmailAddress);
            }
            else if (AddressInfo != null)
            {
                Console.WriteLine("sending message to address {0}", AddressInfo.PostCode);
            }
            else
            {
                // what happens here? Exception? Logging? Ignore?
            }
        }
    }

}

