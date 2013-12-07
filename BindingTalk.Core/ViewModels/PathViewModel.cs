using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace BindingTalk.Core.ViewModels
{
    public class PathViewModel
        : MvxViewModel
    {
        public class Monster
            : MvxNotifyPropertyChanged
        {
            private string _name = "Dalek";
            public string Name 
            {   
                get { return _name; }
                set { _name = value; RaisePropertyChanged(() => Name); }
            }
        }

        private string _monsterName = "Cyberman";
        public string MonsterName 
        {   
            get { return _monsterName; }
            set { _monsterName = value; RaisePropertyChanged(() => MonsterName); }
        }

        private Monster _enemy = new Monster();
        public Monster Enemy 
        {   
            get { return _enemy; }
            set { _enemy = value; RaisePropertyChanged(() => Enemy); }
        }

        private List<Monster> _monsters = new List<Monster>()
            {
                new Monster(),
                new Monster() { Name = "Davros" },
                new Monster() { Name = "The Master" },
                new Monster() { Name = "Todo" }
            };

        public List<Monster> Monsters 
        {   
            get { return _monsters; }
            set { _monsters = value; RaisePropertyChanged(() => Monsters); }
        }

        private Dictionary<string, Monster> _lookup = new Dictionary<string, Monster>()
            {
                { "Dalek", new Monster() },
                { "Davros", new Monster() { Name = "Davros" } },
                { "The Master", new Monster() { Name = "The Master" } },
                { "Todo", new Monster() { Name = "Todo" } }
            };
        public Dictionary<string, Monster> Lookup 
        {   
            get { return _lookup; }
            set { _lookup = value; RaisePropertyChanged(() => Lookup); }
        }
    }
}