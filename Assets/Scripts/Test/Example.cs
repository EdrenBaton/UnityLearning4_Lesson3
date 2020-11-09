using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Test
{
    internal sealed class Example
    {
        private void NameMethod(IPlayerFactory playerFactory)
        {
            IPlayer player = playerFactory.Create(6, TypePlayer.Mag);
            
            IPlayer player3 = Player.Factory.Create(6, TypePlayer.Player);

            Task.Factory.StartNew(Action);
        }

        private void Action()
        {
            Debug.Log(23);
        }
    }

    internal class Player : IPlayer
    {
        public static IPlayerFactory Factory = new PlayerFactory(new WeaponFactory());
        public Player(int hp, Weapon weapon)
        {
            
        }
    }

    internal interface IPlayer
    {
    }

    internal class Mag : IPlayer
    {
        
    }

    internal class PlayerFactory : IPlayerFactory
    {
        private readonly WeaponFactory _weaponFactory;

        public PlayerFactory(WeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;
        }

        public IPlayer Create(int hp, TypePlayer typePlayer)
        {
            switch (typePlayer)
            {
                case TypePlayer.Mag:
                    return new Mag();
                case TypePlayer.Player:
                    return new Player(hp, _weaponFactory.Create());
                case TypePlayer.None:
                default:
                    throw new ArgumentOutOfRangeException(nameof(typePlayer), typePlayer, null);
            }
        }
    }

    internal enum TypePlayer
    {
        None    = 0,
        Mag     = 1,
        Player  = 2,
    }

    internal interface IPlayerFactory
    {
        IPlayer Create(int hp, TypePlayer typePlayer);
    }

    internal class Weapon
    {
        
    }

    internal class WeaponFactory
    {
        internal Weapon Create()
        {
            return new Weapon();
        }
    }
}
