using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionContainer : Exception
{
    public ExceptionContainer(string message) : base(message)
    { }
}
