using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementRequestor 
{
    public event Action<int> OnRequestElements;
}
