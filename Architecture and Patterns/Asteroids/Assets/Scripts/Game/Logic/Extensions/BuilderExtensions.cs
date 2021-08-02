using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravityScale)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.gravityScale = gravityScale;
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject, Vector2 offset, Vector2 size)
        {
            var component  = gameObject.GetOrAddComponent<BoxCollider2D>();
            component.offset = offset;
            component.size = size;
            return gameObject;
        }

        public static GameObject AddTransform(this GameObject gameObject, Vector3 scale)
        {
            var component = gameObject.GetOrAddComponent<Transform>();
            component.localScale = scale;
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite, Color color)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            component.color = color;
            return gameObject;
        }

        public static GameObject AddScript(this GameObject gameObject, string className)
        {
            if (className.Equals("BulletAmmunition"))
                gameObject.GetOrAddComponent<BulletAmmunition>();
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }    
    }
}
