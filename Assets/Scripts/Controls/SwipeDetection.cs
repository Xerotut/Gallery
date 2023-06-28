using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gallery
{
    public static partial class InputReader
    {
        private static class SwipeDetection
        {
            static SwipeDetection()
            {
                _camera = Camera.main;
                OnStartTouch += SwipeStart;
                OnEndTouch += SwipeEnd;
            }


            private static Camera _camera;
            private static Vector2 _startPosition;
            private static Vector2 _endPosition;
            private static float _startTime;
            private static float _endTime;

            private static readonly float minimumDistanceToSwipe = 0.2f;
            private static readonly float maximumTimeToSwipe = 1f;


            private static void SwipeStart(float timeTouched)
            {
                _startPosition = ScreenToWorld(_camera, _phoneControls.SystemActions.FingerPosition.ReadValue<Vector2>());
                _startTime = timeTouched;
            }
            private static void SwipeEnd(float timeStoppedTouching)
            {
                _endPosition = ScreenToWorld(_camera, _phoneControls.SystemActions.FingerPosition.ReadValue<Vector2>());
                _endTime = timeStoppedTouching;

                float distance = Vector3.Distance(_startPosition, _endPosition);
                float time = _endTime - _startTime;
                DetectSwipe(distance, time);
            }


            private static void DetectSwipe(float distance, float time)
            {
                if (distance >=minimumDistanceToSwipe && time <= maximumTimeToSwipe)
                {
                    Vector2 direction = (_endPosition - _startPosition).normalized;
                    SwipeDirection(direction);
                }
            }

            private static void SwipeDirection(Vector2 direction)
            {
                float threshold = 0.9f;
                if (Vector2.Dot(Vector2.up, direction) > threshold)
                {
                    OnSwipeUp?.Invoke();
                } else if (Vector2.Dot(Vector2.down, direction) > threshold)
                {
                    OnSwipeDown?.Invoke();
                } else if (Vector2.Dot(Vector2.left, direction) > threshold)
                {
                    OnSwipeLeft?.Invoke();
                } else if (Vector2.Dot(Vector2.right, direction) > threshold)
                {
                    OnSwipeRight?.Invoke();
                }
            }

            private static Vector3 ScreenToWorld(Camera camera, Vector3 position)
            {
                position.z = camera.nearClipPlane;
                return camera.ScreenToWorldPoint(position);
            }

            

        }


    }
}
