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

namespace Engine
{
    /// <summary>
    /// This class 'handles' all textures. 
    /// </summary>
    public class TextureManager
    {
        Dictionary<string, Texture2D> m_textures;
        ContentManager Content;

        public TextureManager(ContentManager content)
        {
            Content = content;
            m_textures = new Dictionary<string, Texture2D>();
        }

        public void LoadTexture(string name)
        {
            // Check if the texture was already loaded
            if (m_textures.ContainsKey(name))
                return;

            // It wasn't, so load it now
            m_textures.Add(name, Content.Load<Texture2D>(name));
        }

        /// <summary>
        /// Returns the texture given an asset name
        /// </summary>
        /// <param name="name">The asset name to retrieve</param>
        /// <returns></returns>
        public Texture2D GetTexture(string name)
        {
            return m_textures[name];
        }

        /// <summary>
        /// Destructor - cleans up all textures
        /// </summary>
        ~TextureManager()
        {
            if(m_textures.Count>0)
                m_textures.Clear();
        }
    }
}
