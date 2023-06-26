using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery
{
    public class WebSpritesGetter : WebObjectGetter<Sprite>
    {

        public WebSpritesGetter(Action<WebObject<Sprite>> DoOnSpriteAcquisition, bool compress, bool compressHighQuality = true) : base(DoOnSpriteAcquisition)
        {
            _compressSprites = compress;
            _compressSpritesHighQuality = compressHighQuality;
        }

        private bool _compressSprites;
        private bool _compressSpritesHighQuality;

        public override void DownloadWebObject(string url)
        {
            WebUtility.DownloadTexture2D(url, texture => ConvertTextureToSprite(url, texture));
        }

        private void ConvertTextureToSprite(string url, Texture2D texture)
        {
            if (_compressSprites) texture.Compress(_compressSpritesHighQuality);
            Sprite newSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            WebObject<Sprite> downloadedSprite = new WebObject<Sprite>(url, newSprite);
            WebObjectAcquired(downloadedSprite);
        }



    }
}
