﻿using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Creature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }
        public Territory HomeTerritory { get; set; }
        public Item Item { get; set; }
        public CreatureType CreatureType { get; set; }
        public int ItemID { get; set; }
        public int ClassID { get; set; }
        public int RaceID { get; set; }
        public int TerritoryID { get; set; }

        public Creature()
        {

        }

        public Creature(int iD, string name, int age, double height, Class @class, Race race, Territory homeTerritory, CreatureType creatureType, int classID, int raceID, int territoryID)
        {
            ID = iD;
            Name = name;
            Age = age;
            Height = height;
            Class = @class;
            Race = race;
            HomeTerritory = homeTerritory;
            CreatureType = creatureType;
            ClassID = classID;
            RaceID = raceID;
            TerritoryID = territoryID;
        }
    }
}
