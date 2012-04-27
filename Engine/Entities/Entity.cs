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
    public enum EntityType { Sprite, Light };

    public abstract class Entity
    {
        public abstract Dictionary<string, string> SerializeEntity();

        protected bool m_bMirrorHorizontal;
        protected bool m_bMirrorVertical;

        protected Vector2 m_vecPosition;
        protected Color m_colorTint;
        protected string m_strName;
        protected int m_iZ;

        protected string m_strSprite;
        protected string m_strHeightmap;
        protected string m_strNormalmap;
        protected EntityType m_etType;
        protected bool m_bSelected;

        /// <summary>
        /// The position where this floor tile was placed
        /// </summary>
        public Vector2 Position
        {
            get { return m_vecPosition; }
            set { m_vecPosition = value; }
        }

        public bool Selected
        {
            get { return m_bSelected; }
            set { m_bSelected = value; }
        }

        public string Sprite
        {
            get { return m_strSprite; }
            set { m_strSprite = value; }
        }

        public string Heightmap
        {
            get { return m_strHeightmap; }
            set { m_strHeightmap = value; }
        }

        public string Normalmap
        {
            get { return m_strNormalmap; }
            set { m_strNormalmap = value; }
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

        public int Z
        {
            get { return m_iZ; }
            set { if (value >= 0) m_iZ = value; else m_iZ = 0; }
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

        public EntityType Type
        {
            get { return m_etType; }
        }

        public Entity()
        {
            m_colorTint = Color.White;
            m_bMirrorHorizontal = false;
            m_bMirrorVertical = false;
        }
    }
}
