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
        AssetManager texMan;

        public World(AssetManager tex)
        {
            texMan = tex;
            m_lstEntities = new List<Entity>();
        }

        public void AddEntity(Entity ent)
        {
            m_lstEntities.Add(ent);

            if(ent.Type==EntityType.Sprite)
                texMan.LoadTexture(ent);
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

        public void SortEntities()
        {
            for (int i = 0; i < m_lstEntities.Count; i++)
            {
                for (int j = i; j < m_lstEntities.Count; j++)
                {
                    if (m_lstEntities[i].Position.Y > m_lstEntities[j].Position.Y)
                    {
                        Entity tempi = m_lstEntities[i];
                        m_lstEntities[i] = m_lstEntities[j];
                        m_lstEntities[j] = tempi;
                    }
                }
            }
        }
    }
}
