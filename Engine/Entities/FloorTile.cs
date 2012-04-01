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
    /// <summary>
    /// The different types of floor that can exist
    /// </summary>
    public enum FloorTypes { TestFloor };

    public class FloorTile : Entity
    {
        private FloorTypes m_eFloorType;

        /// <summary>
        /// The FloorType determines what kind of floor we're 
        /// using right now - a checkerboard?
        /// </summary>
        public FloorTypes FloorType
        {
            get { return m_eFloorType; }
            set { m_eFloorType = value; UpdateFloorSprite(); }
        }

        private void UpdateFloorSprite()
        {
            switch(m_eFloorType)
            {
                case FloorTypes.TestFloor:
                    Sprite = "floorTest";
                    break;

                default:
                    Sprite = "floorTest";
                    break;
            }
        }

        public FloorTile()
        {
            Position = new Vector2(0, 0);
            FloorType = FloorTypes.TestFloor;
            MirrorHorizontal = false;
            MirrorVertical = false;

            UpdateFloorSprite();
        }

        public override Dictionary<string, string> SerializeEntity()
        {
            return null;
        }
    }
}
