using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

namespace Gallery
{
    public class WebImageElementSpawner: ElementSpawner<WebObject<Sprite>, ElementRequestor>
    {
        WebSpritesGetter _spriteGetter;

        private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/1.jpg";

        private bool _allowRequests = true;

        protected override void Awake()
        {
            base.Awake();
            _spriteGetter = new WebSpritesGetter(SpawnElement, true, false);

        }

        protected override void SatisfyElementRequirement(int numberOfElements)
        {
            if (_allowRequests)
            {
                Debug.Log("halo");
                _allowRequests = false;
                for (int i = 0; i < numberOfElements; i++)
                {
                    _spriteGetter.DownloadWebObject(_url);
                }
                
            }
        }

        protected override void SpawnElement(WebObject<Sprite> elementData)
        {
            base.SpawnElement(elementData);
            _allowRequests = true;
        }

    }
}
