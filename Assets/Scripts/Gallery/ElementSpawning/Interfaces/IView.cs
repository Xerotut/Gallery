using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView 
{

    public event Action<int, IView> OnViewRequest;

    public void OnRequestAnswered(bool isImageExists);

    public void OnSpriteReady(Sprite sprite);
}
