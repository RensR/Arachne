using System;

namespace Arachne.Data.Enums
{
    [Flags]
    public enum Permission
    {
        Profile = 0b_0000_0000_0001,
        EmailAddress = 0b_0000_0000_0010,
        PhoneNumber = 0b_0000_0000_0100,
        Address = 0b_0000_0000_1000,
    }
}