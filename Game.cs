using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestovoeLesta.Characters;
using TestovoeLesta.Characters.Enemies;
using TestovoeLesta.Characters.Heroes;
using TestovoeLesta.Weapons;

namespace TestovoeLesta
{
    public class Game
    {
        public static int CurrentFightTurn { get; private set; } = 0;

        private CharacterFactory _characterFactory;
        private List<Enemy> _enemies = new List<Enemy>();
        private Hero _player;

        public Game()
        {
            Initialize();
        }

        private void Initialize()
        {
            Console.WriteLine("Выберите начальный класс героя");
            _characterFactory = new CharacterFactory();
            Hero hero = null;

            while (hero == null)
            {
                hero = ChooseHero();
            }

            _player = hero;
            Console.WriteLine($"Добро пожаловать {_player.GetType().Name}");

            var enemyTypes = Enum.GetValues<EnemyType>().ToList();
            
            foreach (var enemyType in enemyTypes)
            {
                _enemies.Add(_characterFactory.GetEnemy(enemyType));
            }
        }

        public void GameLoop()
        {
            while (true)
            {
                if (_enemies.Count == 0)
                {
                    Console.WriteLine("Вы победили");
                    break;
                }    
                Fight();

                if (_player.IsDead)
                    break;

                if (_player.SummaryLevel() != 3)
                    LevelUp();
                
                _player.ResetHealth();
            }

            Console.WriteLine("Игра окончена!");
        }

        private void LevelUp()
        {
            List<Hero> playerAvailibleClasses = new List<Hero>();
            playerAvailibleClasses.Add(_player);

            foreach (var extraClass in _player.Classes)
            {
                playerAvailibleClasses.Add(extraClass);
            }

            Console.WriteLine("1 - Улучшить текущие классы");
            Console.WriteLine("2 - Добавить новый класс");

            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out int choose))
                {
                    if (choose <= 0 || choose >= 3)
                    {
                        Console.WriteLine("Неправильный ввод");
                        continue;
                    }
                    else if (choose == 1)
                    {
                        Console.WriteLine("Выберите класс для улучшения");

                        for (int i = 0; i < playerAvailibleClasses.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {playerAvailibleClasses[i].GetType().Name}");
                        }

                        input = Console.ReadLine();

                        if (int.TryParse(input, out choose))
                        {
                            if (choose <= 0 || choose > playerAvailibleClasses.Count)
                            {
                                Console.WriteLine("Неправильный ввод");
                                continue;
                            }

                            playerAvailibleClasses[choose-1].LevelUp();
                            break;
                        }    
                    }
                    else
                    {
                        var newClass = ChooseHero();
                        
                        if (newClass == null)
                        {
                            Console.WriteLine("Неправильный ввод");
                            continue;
                        }    

                        _player.AddNewClass(newClass);
                        break;
                    }
                }

                Console.WriteLine("Неправильный ввод");
            }
        }

        private void TakeDroppedWeapon()
        {
            var droppedItem = _enemies[0].DropItem();
            Console.WriteLine($"С врага выпал {droppedItem.Name}, кол-во урона - {droppedItem.Damage}, тип урона - {droppedItem.DamageType}");
            Console.WriteLine("Желаете сменить орудие?\n 1 - Да\n 2 - Нет");

            var input = Console.ReadLine();
            int choose;

            while (true)
            {
                if (int.TryParse(input, out choose))
                {
                    if (choose <= 0 || choose > 2)
                    {
                        Console.WriteLine("Неправильный ввод");
                        continue;
                    }
                    else if (choose == 1)
                    {
                        Console.WriteLine("Вы подняли оружие");
                        _player.TakeWeapon(droppedItem);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы пропустили оружие");
                        break;
                    }
                }
            }
        }

        public void Fight()
        {
            var enemy = _enemies[0];
            Console.WriteLine($"Вы встретили врага - {enemy.GetType().Name}");

            while (!enemy.IsDead && !_player.IsDead)
            {
                CurrentFightTurn++;

                Console.WriteLine($"Здоровье игрока - {_player.Health}");
                Console.WriteLine($"Здоровье врага - {enemy.Health}");
                Console.WriteLine($"Игрок аттакует {enemy.GetType().Name}");
                _player.Attack(enemy);

                if (enemy.IsDead)
                {
                    Console.WriteLine($"{enemy.GetType().Name} побежден");
                    TakeDroppedWeapon();
                    _enemies.Remove(enemy);
                    break;
                }
                    

                enemy.Attack(_player);
                Console.WriteLine($"Враг аттакует игрока");
            }

            CurrentFightTurn = 0;
        }

        public Hero ChooseHero()
        {
            Console.WriteLine("Доступные классы героя\n");

            var availibleTypes = Enum.GetValues<HeroType>().ToList();

            if (_player != null)
            {
                availibleTypes.Remove(Enum.Parse<HeroType>(_player.GetType().Name));

                foreach (var usedClass in _player.Classes)
                {
                    availibleTypes.Remove(Enum.Parse<HeroType>(usedClass.GetType().Name));
                }
            }

            for (int i = 0; i < availibleTypes.Count; i++)
            {
                Console.WriteLine($"{(int)availibleTypes[i]} - {availibleTypes[i].ToString()}");
            }

            Console.Write("Введите номер выбранного героя - ");
            var input = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(input, out int choose))
            {
                if (choose < (int)availibleTypes[0] || choose > Enum.GetValues<HeroType>().Length)
                {
                    Console.WriteLine("Неправильный ввод");
                    return null;
                }

                return _characterFactory.GetHero((HeroType)(choose));
            }

            Console.WriteLine("Неправильный ввод");
            return null;
        }
    }
}
