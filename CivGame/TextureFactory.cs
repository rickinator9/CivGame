using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivGame
{
    /// <summary>
    /// Factory to create instances of Texture2D objects.
    /// </summary>
    class TextureFactory
    {
        private GraphicsDevice _graphicsDevice;
        
        public TextureFactory(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        /// <summary>
        /// Generates a Texture2D object with the desired texture.
        /// </summary>
        /// <param name="color">The desired color of the Texture2D.</param>
        /// <param name="width">The desired width of the Texture2D.</param>
        /// <param name="height">The desired height of the Texture2D.</param>
        /// <returns>A Texture2D object made up of a single color.</returns>
        public Texture2D createColoredTexture(Color color, int width = 100, int height = 100)
        {
            // Make sure that color is not null.
            if (color == null) throw new ArgumentNullException("color");

            // Create a array of color data for the texture.
            var data = new Color[width * height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    data[y * height + x] = color;
                }
            }

            // Create the texture and set the data.
            Texture2D texture = new Texture2D(_graphicsDevice, width, height);
            texture.SetData(data);

            // Return the texture.
            return texture;
        }
    }
}
