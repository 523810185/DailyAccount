#if UNITY_EDITOR
//-----------------------------------------------------------------------
// <copyright file="ExampleHelper.cs" company="Sirenix IVS">
// Copyright (c) Sirenix IVS. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Sirenix.OdinInspector.Editor.Examples
{
#pragma warning disable

    using System.Collections.Generic;
    using System.Linq;
    using Sirenix.Utilities.Editor;
    using UnityEngine;

    internal static class ExampleHelper
    {
        private static readonly System.Random random = new System.Random();

        private static readonly string[] shaderNames = { "Standard", "Specular", "Skybox/Cubemap" };

        private static readonly string[] strings = { "Hello World", "Sirenix", "Unity", "Lorem Ipsum", "Game Object", "Scriptable Objects", "Ramblings of a mad man" };

        private static readonly string[] meshNames = { "Cube", "Sphere", "Cylinder", "Capsule" };

        public static T GetScriptableObject<T>() where T: ScriptableObject
        {
            return ScriptableObject.CreateInstance<T>();
        }

        public static Material GetMaterial()
        {
            return new Material(Shader.Find(PickRandom(shaderNames)));
        }

        public static Texture2D GetTexture()
        {
            switch (random.Next(10))
            {
                default:
                case 0: return EditorIcons.OdinInspectorLogo;
                case 1: return EditorIcons.UnityLogo;
                case 2: return (Texture2D)EditorIcons.Upload.Active;
                case 3: return (Texture2D)EditorIcons.Pause.Active;
                case 4: return (Texture2D)EditorIcons.Paperclip.Active;
                case 5: return (Texture2D)EditorIcons.Pen.Active;
                case 6: return (Texture2D)EditorIcons.Play.Active;
                case 7: return (Texture2D)EditorIcons.SettingsCog.Active;
                case 8: return (Texture2D)EditorIcons.ShoppingBasket.Active;
                case 9: return (Texture2D)EditorIcons.Sound.Active;
            }
        }

        public static Mesh GetMesh()
        {
            string name = PickRandom(meshNames);
            return Resources.FindObjectsOfTypeAll<Mesh>().FirstOrDefault(x => x.name == name);
        }

        public static string GetString()
        {
            return PickRandom(strings);
        }

        private static T PickRandom<T>(IList<T> collection)
        {
            return collection[random.Next(collection.Count)];
        }
    }
}
#endif