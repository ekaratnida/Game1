using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Control
{
    public class Input
    {
        MouseState mouse_state;

        public static void Update(GameTime gameTime) {
            // get elapsed frame time in seconds
            //frame_time = gameTime.ElapsedGameTime.Milliseconds / 1000.0;

            // update mouse variables
            //mouse_state = Mouse.GetState();
        }
       
        public MouseState GetMouseState() { return mouse_state; }
        
    }
}
