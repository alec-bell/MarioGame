using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class KeyboardController : IController
    {
        //Action Enum is declared in IController
        private Dictionary<Keys, ICommand> keysMap;

        public KeyboardState previousKeyboardState;
        private List<Keys> PreviousKeys { get; set; }
        //TEMPORARILY PUBLIC
        public List<Keys> CurrentKeys { get; set; } = new List<Keys>();
        

        // Takes an action as a parameter and returns true if the key mapped to that action 
        //is currently being pressed and was previously pressed
        public bool CommandRepeated(ICommand command)
        {
            
            Keys key = Keys.None;
            foreach(Keys k in keysMap.Keys)
            {
                if(command == keysMap[k])
                {
                     key = k;
                }
            }
            return Keyboard.GetState().IsKeyDown(key) && PreviousKeys.Contains(key);

        }

        public bool CommandReleased(ICommand command)
        {
            Keys key = Keys.None;
            foreach (Keys k in keysMap.Keys)
            {
                if (command == keysMap[k])
                {
                    key = k;
                }
            }

            return !Keyboard.GetState().IsKeyDown(key) && PreviousKeys.Contains(key);
        }

        //Converts pressed keys into Actions
        public List<ICommand> GetCommand(int i)
        {
            return null;
        }

        /*public bool PluggedIn(int i)
        {
            //We're going to assume the keyboard is always plugged in
            return true;
        }*/

        //Set previousKeys to current keys and 
        //set currentKeys to the pressed keys
        public void Update()
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();
            Keys[] keysPressed = currentKeyboardState.GetPressedKeys();
            foreach (Keys key in keysPressed)
            {
                if (!previousKeyboardState.IsKeyDown(key))
                {
                    if (keysMap.ContainsKey(key))
                        keysMap[key].Execute();
                }
            }
            previousKeyboardState = currentKeyboardState;
        }

        //Public constructor for the Dictionary that maps Keys to Actions
        public KeyboardController(Dictionary<Keys, ICommand> keysMap) 
        {
            //Save the passed in keys map to a local variable
            this.keysMap = keysMap;
            previousKeyboardState = Keyboard.GetState();
        }

    }
}
