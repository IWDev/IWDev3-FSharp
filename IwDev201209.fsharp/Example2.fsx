// ==============================
// Version 1
// ==============================

type NameInfo = {
    First :string; 
    MiddleInitial :string option;
    Last :string; 
    }

type EmailInfo = {
    EmailAddress :string
    EmailIsValid :bool
    EmailIsVerified :bool
}

type AddressInfo = {
    Address1 :string; 
    Address2 :string option; 
    Town :string; 
    PostCode :string; 

    AddressIsValid :bool; 
}

type ContactInfo = {
    Name :NameInfo; 
    EmailInfo :EmailInfo;
    AddressInfo :AddressInfo;
}












// ==============================
// Version 2
// ==============================

type AddressInfoState =
    | Valid of AddressInfo
    | Invalid of AddressInfo

type EmailInfoState = 
    | Invalid of string
    | ValidNotVerified of string
    | Verified of string

type ContactInfoState =
    | EmailOnly of EmailInfoState
    | AddressOnly of AddressInfoState
    | EmailAndAddress of EmailInfoState * AddressInfoState

type ContactInfo2 = {
    Name :NameInfo; 
    ContactInfoState :ContactInfoState;
}



















// ==============================
// Case processing
// ==============================

let SendMessage contactInfo = 
    match contactInfo.ContactInfoState with
    // you are forced to deal with each case
    | EmailOnly emailInfo
    | EmailAndAddress (emailInfo,_) ->
        printfn "sending message to email %A" emailInfo

    | AddressOnly addrInfo ->
        printfn "sending message to addr %A" addrInfo
