using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command
{

class Program
    {
        static void Main(string[] args)
        {
            GamepadInvoker gamepad = new GamepadInvoker();

            gamepad.SetCommand('A', new ShootCommand());
            gamepad.SetCommand('B', new JumpCommand());
            gamepad.SetCommand('X', new ChangeWeaponCommand());
            gamepad.SetCommand('Y', new RunCommand());
            Console.WriteLine("Игрок нажал кнопку A");
            gamepad.PressButton('A');

            Console.WriteLine("Игрок нажал кнопку B");
            gamepad.PressButton('B');

            Console.WriteLine("Игрок нажал кнопку X");
            gamepad.PressButton('X');

            Console.WriteLine("Игрок нажал кнопку Y");
            gamepad.PressButton('Y');

            Console.WriteLine("Переназначение кнопки A на смену оружия");
            gamepad.SetCommand('A', new ChangeWeaponCommand());

            Console.WriteLine("Игрок снова нажал кнопку A");
            gamepad.PressButton('A');
        }
    }
    public class GamepadInvoker
    {
        private Dictionary<char, ICommand> _commands = new Dictionary<char, ICommand>();

        public void SetCommand(char button, ICommand command)
        {
            _commands[button] = command;
        }

        public void PressButton(char button)
        {
            if (_commands.ContainsKey(button))
            {
                _commands[button].Execute();
            }
            else
            {
                Console.WriteLine($"Команда для кнопки '{button}' не назначена.");
            }
        }
    }
    public interface ICommand
    {
        void Execute();
    }
    public class ShootCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Персонаж выстрелил из оружия!");
        }
    }

    public class JumpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Персонаж совершил прыжок!");
        }
    }

    public class ChangeWeaponCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Персонаж сменил оружие!");
        }
    }

    public class RunCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Персонаж ускорился!");
        }
    }
}
