using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImageRequestor 
{
    public void OnRequestAnswered(bool isImageExists);

    public void OnSpriteReady(Sprite sprite);
}
