using System;

public class NotEnoughGoldException : Exception
{
    public NotEnoughGoldException() {}

    public NotEnoughGoldException(string message) : base(message) {}
}
