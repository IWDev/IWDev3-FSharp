// ==============================
// Version 1
// ==============================

type EmailInfo = 
    {
        EmailAddress: string;

        /// True if the email conforms to RFC format
        IsValid:bool;

        /// True if the email has been sent to customer to confirm ownership
        IsVerified:bool;
    }

    // How many bugs are there in this code?












// immutable, so no possible bugs in the set methods!




// but how to meet other requirements?






// fails to meet requirements!
let emailInfo = { EmailAddress="bill@gmail.com"; IsValid=false; IsVerified=true; }














// union types to the rescue!














// ==============================
// Version 2
// ==============================

type EmailInfoState = 
    | Invalid of string
    | ValidNotVerified of string
    | Verified of string


let validEmail = ValidNotVerified "bill@gmail.com"
let invalidEmail = Invalid "bad bad bad"




















// ==============================
// List processing
// ==============================



// forced to deal with each case
let sendEmails listOfEmails = 
    listOfEmails 
    |> List.iter (function
        | Invalid email -> printfn "skipping '%s'" email
        | ValidNotVerified email -> printfn "sending verification to '%s'" email
        | Verified email -> printfn "sending private message to '%s'" email
    )

sendEmails [validEmail; invalidEmail]

// Is this code order dependent?
// What happens if a new state is added?
