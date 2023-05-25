using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughGoldException : Exception
{
    public NotEnoughGoldException() {}

    public NotEnoughGoldException(string message) : base(message) {}
}
