using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Engine.Entities;

namespace Engine
{
    /// <summary>
    /// This class stores the state of the world. 
    /// </summary>
    public class World
    {
        List<Entity> m_lstEntities;
        TextureManager texMan;

        public World(TextureManager tex)
        {
            texMan = tex;
            m_lstEntities = new List<Entity>();
        }

        public void AddEntity(Entity ent)
        {
            m_lstEntities.Add(ent);
            texMan.LoadTexture(ent.Sprite);
        }

        public void SaveMap(string file)
        {
        }

        public void LoadMap(string file)
        {
        }

        public int GetEntityCount()
        {
            return m_lstEntities.Count;
        }

        public Entity GetEntity(int index)
        {
            return m_lstEntities[index];
        }

        public List<Entity> GetEntities()
        {
            return m_lstEntities;
        }
    }
}
