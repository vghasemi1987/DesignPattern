﻿using System;
using State.Refactored.Abstraction;
using State.Refactored.StateMachineContext;

namespace State
{
    public class SoldOutState : IState
    {
        public GumballMachine Machine { get; }

        public SoldOutState(GumballMachine gumballMachine)
        {
            Machine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Sorry! Sold Out");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Can't eject when sold out");
        }

        public void TurnCrank()
        {
            Console.WriteLine("turning crank achieves nothing");
        }

        public void Dispense()
        {
            Console.WriteLine("Can't dispense when out of stock");
        }
    }
}