using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

namespace Heartfield
{
    public static class CaptureScreenshot
    {
        public enum FileFormat
        {
            PNG,
            JPG,
            TGA,
            EXR
        }

        struct Info
        {
            internal Camera camera;
            internal int width;
            internal int height;
            internal string path;
            internal Action<Texture2D> onScreenshot;
        }

        static Camera mainCamera;
        static Queue<Info> screenshotQueue = new Queue<Info>();

        static CaptureScreenshot()
        {
            MonoBehaviourHelper.OnPostRender += OnPostRender;
        }

        static void OnPostRender()
        {
            while (screenshotQueue.Count > 0)
            {
                var info = screenshotQueue.Dequeue();
                var renderTexture = info.camera.targetTexture;
                var result = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
                var rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
                result.ReadPixels(rect, 0, 0);

                RenderTexture.ReleaseTemporary(renderTexture);
                info.camera.targetTexture = null;

                info.onScreenshot(result);

                return;
            }
        }

        static void TakeScreenshot(Camera camera, int width, int height, string path, Action<Texture2D> onScreenshot)
        {
            camera.targetTexture = RenderTexture.GetTemporary(width, height);

            var info = new Info()
            {
                camera = camera,
                width = width,
                height = height,
                path = path,
                onScreenshot = onScreenshot
            };

            screenshotQueue.Enqueue(info);
        }

        static Texture2D Capture(Camera camera, int width, int height, string path, FileFormat fileFormat, int quality = 75, Texture2D.EXRFlags flags = Texture2D.EXRFlags.None)
        {
            Texture2D result = null;

            TakeScreenshot(camera, width, height, path, (Texture2D texture) =>
            {
                byte[] byteArray;

                if (fileFormat == FileFormat.JPG)
                    byteArray = texture.EncodeToJPG(quality);
                else if (fileFormat == FileFormat.PNG)
                    byteArray = texture.EncodeToPNG();
                else if (fileFormat == FileFormat.EXR)
                    byteArray = texture.EncodeToEXR(flags);
                else
                    byteArray = texture.EncodeToTGA();

                File.WriteAllBytes(path, byteArray);
                result = texture;
            });

            return result;
        }

        #region JPG
        public static Texture2D CaptureJPG(Camera camera, int width, int height, int quality, string path)
        {
            return Capture(camera, width, height, path, FileFormat.JPG, quality);
        }

        public static Texture2D CaptureJPG(Camera camera, int width, int height, string path)
        {
            return CaptureJPG(camera, width, height, 75, path);
        }

        public static Texture2D CaptureJPG(Camera camera, string path)
        {
            return CaptureJPG(camera, Screen.width, Screen.height, path);
        }

        public static Texture2D CaptureJPG(int width, int height, string path)
        {
            if (mainCamera == null)
                mainCamera = Camera.main;

            return CaptureJPG(mainCamera, width, height, path);
        }

        public static Texture2D CaptureJPG(int width, int height, int quality, string path)
        {
            if (mainCamera == null)
                mainCamera = Camera.main;

            return CaptureJPG(mainCamera, width, height, quality, path);
        }

        public static Texture2D CaptureJPG(string path)
        {
            return CaptureJPG(Screen.width, Screen.height, path);
        }

        public static Texture2D CaptureJPG(int quality, string path)
        {
            return CaptureJPG(Screen.width, Screen.height, quality, path);
        }
        #endregion

        #region PNG
        public static Texture2D CapturePNG(Camera camera, int width, int height, string path)
        {
            return Capture(camera, width, height, path, FileFormat.PNG);
        }

        public static Texture2D CapturePNG(Camera camera, string path)
        {
            return CapturePNG(camera, Screen.width, Screen.height, path);
        }

        public static Texture2D CapturePNG(int width, int height, string path)
        {
            if (mainCamera == null)
                mainCamera = Camera.main;

            return CapturePNG(mainCamera, width, height, path);
        }

        public static Texture2D CapturePNG(string path)
        {
            return CapturePNG(Screen.width, Screen.height, path);
        }
        #endregion
    }
}