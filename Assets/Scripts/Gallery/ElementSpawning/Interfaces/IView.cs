using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView 
{
    public void OnRequestAnswered(bool isImageExists);

    public void OnSpriteReady(Sprite sprite);
}
