using System;
using System.Collections.Generic;

namespace IwDev201209
{
    // ==============================
    // Version 1
    // ==============================
    public class EmailInfo
    {
        public string EmailAddress { get; set; }

        /// <summary>
        /// True if the email conforms to RFC format
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// True if the email has been sent to customer to confirm ownership
        /// </summary>
        public bool IsVerified { get; set; }
    }


    // How many bugs are there in this code?















    /*

    Requirements
     * email address can never be null (set the whole structure to null instead) 
     * A new email must have IsVerified and IsValid both false.
     * Can't have IsVerified if IsValid is false.
  
    */


    // ==============================
    // Version 2
    // ==============================
    public class EmailInfo2
    {
        private string _emailAddress;

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value == null) { throw new ArgumentException("EmailAddress"); }

                _emailAddress = value;
                IsValid = false;
                IsVerified = false;
            }
        }

        public bool IsValid { get; set; }

        public bool IsVerified { get; set; }
    }













    // ==============================
    // Version 3
    // ==============================
    public class EmailInfo3
    {
        private string _emailAddress;
        private bool _isVerified;

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value == null) { throw new ArgumentException("EmailAddress"); }

                _emailAddress = value;
                IsValid = false;
                IsVerified = false;
            }
        }

        public bool IsValid { get; set; }

        public bool IsVerified
        {
            get { return _isVerified; }
            set { _isVerified = IsValid ? value : false; }
        }

















        // ==============================
        // Processing a list
        // ==============================

        /// <summary>
        /// Send email
        /// * If not valid -- do nothing
        /// * If valid but not verified -- send a verification email
        /// * If verified -- send a message 
        /// </summary>
        public void SendEmails(IEnumerable<EmailInfo3> listOfEmails)
        {
            foreach (var email in listOfEmails)
            {
                if (!email.IsValid)
                {
                    Console.WriteLine("skipping '{0}'", email.EmailAddress);
                }
                else if (!email.IsVerified)
                {
                    Console.WriteLine("sending verification to '{0}'", email.EmailAddress);
                }
                else
                {
                    Console.WriteLine("sending private message to  '{0}'", email.EmailAddress);
                }

            }
        }

    }
}

