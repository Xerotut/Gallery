using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public abstract class WebObjectGetter<T>
    {
        public WebObjectGetter(Action<WebObject<T>> DoOnWebObjectAcquisition)
        {
            OnWebObjectAcquired += DoOnWebObjectAcquisition;
        }

        private event Action<WebObject<T>> OnWebObjectAcquired;

        public abstract void DownloadWebObject(string url);

        protected void WebObjectAcquired(WebObject<T> webObject) => OnWebObjectAcquired?.Invoke(webObject);
    }
}