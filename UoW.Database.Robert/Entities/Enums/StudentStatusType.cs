namespace UoW.Database.Robert.Entities.Enums
{
    using System;

    [Flags]
    public enum StudentStatusType
    {
        Active = 1,
        Inactive = 2,
        ExtendedAbsence = 4,
        Deceased = 8,
        Defaulted = 16,
        Suspended = 32,
        Rusticated = 64
    }
}
