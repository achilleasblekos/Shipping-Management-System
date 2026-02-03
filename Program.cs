using System;
using System.Collections.Generic;
using ShippingSystem.Domain;
using ShippingSystem.UI;

Ship ship1 = new("Hercules", 450);
Ship ship2 = new("Copacabana", 650);
Ship ship3 = new("Hermes", 250);
Ship ship4 = new("Zeus", 500);

List<Ship> ships = [ship1, ship2, ship3, ship4];


ConsoleMenu menu = new(ships);
menu.Show();