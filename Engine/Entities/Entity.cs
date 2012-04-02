using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine.Entities
{
    public abstract class Entity
    {
        public abstract Dictionary<string, string> SerializeEntity();

        protected bool m_bMirrorHorizontal;
        protected bool m_bMirrorVertical;

        protected Vector2 m_vecPosition;
        protected string m_strSprite;
        protected Color m_colorTint;
        protected string m_strName;

        /// <summary>
        /// The position where this floor tile was placed
        /// </summary>
        public Vector2 Position
        {
            get { return m_vecPosition; }
            set { m_vecPosition = value; }
        }

        public string Sprite
        {
            get { return m_strSprite; }
            set { m_strSprite = value; }
        }

        public bool MirrorHorizontal
        {
            get { return m_bMirrorHorizontal; }
            set { m_bMirrorHorizontal = value; }
        }

        public bool MirrorVertical
        {
            get { return m_bMirrorVertical; }
            set { m_bMirrorVertical = value; }
        }

        public Color Tint
        {
            get { return m_colorTint; }
            set { m_colorTint = value; }
        }

        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        public Entity()
        {
            m_colorTint = Color.White;
            m_bMirrorHorizontal = false;
            m_bMirrorVertical = false;
        }
    }
}
