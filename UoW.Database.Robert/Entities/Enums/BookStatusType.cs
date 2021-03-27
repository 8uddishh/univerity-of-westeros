namespace UoW.Database.Robert.Entities.Enums
{
    using System;

    [Flags]
    public enum BookStatusType : int
    {
        New = 1,
        Used = 2,
        Borrowed = 4,
        Available = 8,
        Missing = 16,
        Lost = 32,
        Damaged = 64
    }
}
