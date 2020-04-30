using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    
    /// <summary>
    /// Need to declare this for each instance of controller
    /// </summary>
     class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> ButtonsMap { get; set; }
        private GamePadState PreviousButtons { get; set; }
        private GamePadState CurrentButtons { get; set; }
        private int PlayerIndex { get; set; }
        
        public bool CommandRepeated(ICommand command, GamePadState prevButtons)
        {
            //Have to assign this to 0 because there is no 'Buttons.None'
            Buttons button = 0;
            foreach (Buttons b in ButtonsMap.Keys)
            {
                if (command == ButtonsMap[b])
                {
                    button = b;
                }
            }
            return GamePad.GetState(PlayerIndex).IsButtonDown(button) && prevButtons.IsButtonDown(button);
        }

        public bool CommandReleased(ICommand com, GamePadState currentButtons, GamePadState previousButtons)
        {
            Buttons button = 0;
            foreach (Buttons b in ButtonsMap.Keys)
            {
                if (com == ButtonsMap[b])
                {
                    button = b;
                }
            }
            return !currentButtons.IsButtonDown(button) && previousButtons.IsButtonDown(button);
        }

        public List<ICommand> GetCommand(int playerIndex)
        {
            List<ICommand> pressed = new List<ICommand>();
            if (GamePad.GetState(playerIndex).Buttons.Start == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.Start))
            {
                pressed.Add(ButtonsMap[Buttons.Start]);
            }
            if (GamePad.GetState(playerIndex).Buttons.A == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.A))
            {
                pressed.Add(ButtonsMap[Buttons.A]);
            }
            if (GamePad.GetState(playerIndex).Buttons.B == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.B))
            {
                pressed.Add(ButtonsMap[Buttons.B]);
            }
            if (GamePad.GetState(playerIndex).Buttons.X == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.X))
            {
                pressed.Add(ButtonsMap[Buttons.X]);
            }
            if (GamePad.GetState(playerIndex).Buttons.Y == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.Y))
            {
                pressed.Add(ButtonsMap[Buttons.Y]);
            }
            if (GamePad.GetState(playerIndex).Buttons.Back == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.Back))
            {
                pressed.Add(ButtonsMap[Buttons.Back]);
            }
            if (GamePad.GetState(playerIndex).DPad.Up == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.DPadUp))
            {
                pressed.Add(ButtonsMap[Buttons.DPadUp]);
            }
            if (GamePad.GetState(playerIndex).DPad.Right == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.DPadRight))
            {
                pressed.Add(ButtonsMap[Buttons.DPadRight]);
            }
            if (GamePad.GetState(playerIndex).DPad.Left == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.DPadLeft))
            {
                pressed.Add(ButtonsMap[Buttons.DPadLeft]);
            }
            if (GamePad.GetState(playerIndex).DPad.Down == ButtonState.Pressed && !PreviousButtons.IsButtonDown(Buttons.DPadDown))
            {
                pressed.Add(ButtonsMap[Buttons.DPadDown]);
            }

            return pressed;
        }

        //already implemented for us
        public bool PluggedIn(int playerIndex)
        {
            return GamePad.GetState(playerIndex).IsConnected;

        }

        //set the previous buttons to the old GamePad State
        //and set current buttons to the current GamePad state
        public void Update()
        {
            if (PluggedIn(PlayerIndex))
            {
                PreviousButtons = CurrentButtons;
                CurrentButtons = GamePad.GetState(PlayerIndex);
                List<ICommand> commands = GetCommand(PlayerIndex);
                foreach (ICommand cmd in commands)
                {
                    cmd.Execute();
                }
            }
        }
        

        //Public constructor for the dictionary that maps Buttons to Actions
        public GamepadController(Dictionary<Buttons, ICommand> buttonsMap, int playerIndex)
        {
            this.ButtonsMap = buttonsMap;
            this.PlayerIndex = playerIndex;
        }

    }
}
