using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Maker
{
    public class Monster
    {
        public int acrobatics = 0;
        internal List<Action> actions = new List<Action>();
        public string alignment = "any alignment";
        public int animalHandling;
        public int arcana;
        public int armor_class;
        public int athletics;
        public int challenge_rating;
        public int charisma;
        public int charisma_save;
        public string condition_immunities;
        public int constitution;
        public int constitution_save;
        public string damage_immunities = null;
        public string damage_resistances = null;
        public string damage_vulnerabilities = null;
        public int deception;
        public int dexterity;
        public int dexterity_save;
        public int history;
        public string hit_dice = null;
        public int hit_points;
        public int insight;
        public int intelligence;
        public int intelligence_save;
        public int intimidation;
        public int investigation;
        public string languages;
        internal List<LegendaryAction> legendary_actions = new List<LegendaryAction>();
        public string manual = null;
        public int medicine;
        public string name = null;
        public int nature;
        public int perception;
        public int performance;
        public int persuasion;
        internal List<Reaction> reactions = new List<Reaction>();
        public int religion;
        public string senses = null;
        public string size;
        public int sleightOfHand;
        internal List<SpecialAbility> special_abilities = new List<SpecialAbility>();
        public string speed = null;
        public int stealth;
        public int strength;
        public int strength_save;
        public string subtype = null;
        public int survival;
        public string type = null;
        public int wisdom;
        public int wisdom_save;
        
        internal void addAction(List<Action> input)
        {
            // = input
            actions = new List<Action>();
            foreach (var item in input)
            {
                actions.Add(item);
            }
        }
        internal void addSpecialAbility(List<SpecialAbility> input)
        {
            special_abilities = input;
        }
        internal void addReaction(List<Reaction> input)
        {
            reactions = input;
        }
        internal void addLegendaryAction(List<LegendaryAction> input)
        {
            legendary_actions = input;
        }
        public string AddPassiveToSenses(){
            if (senses.Equals(""))
            {
                return "passive Perception "+CalculatePassivePerception();
            }else
            {
                return "., passive Perception " + CalculatePassivePerception();
            }
        }
        private int CalculatePassivePerception()
        {
            int wisdom_bonus = CalculateAbilityBonus(wisdom);
            int standard = 10;
            if (perception >= wisdom_bonus)
            {
                int output = standard + perception;
                return output;
            }
            else
            {
                int output = standard + wisdom_bonus;
                return output;
            }
        }
        public void insert_AbilityBonus()
        {
            strength_save = CalculateAbilityBonus(strength);
            dexterity_save = CalculateAbilityBonus(dexterity);
            constitution_save = CalculateAbilityBonus(constitution);
            intelligence_save = CalculateAbilityBonus(intelligence);
            wisdom_save = CalculateAbilityBonus(wisdom);
            charisma_save = CalculateAbilityBonus(charisma);
        }
        private int CalculateAbilityBonus(int input)
        {
            switch (input)
            {
                case 1: return -5;
                case 2:
                case 3: return -4;
                case 4:
                case 5: return -3;
                case 6:
                case 7: return -2;
                case 8:
                case 9: return -1;
                case 10:
                case 11: return 0;
                case 12:
                case 13: return 1;
                case 14:
                case 15: return 2;
                case 16:
                case 17: return 3;
                case 18:
                case 19: return 4;
                case 20:
                case 21: return 5;
                case 22:
                case 23: return 6;
                case 24:
                case 25: return 7;
                case 26:
                case 27: return 8;
                case 28:
                case 29: return 9;
                case 30: return 10;
            }
            return 0;
        }
        override
        public string ToString()
        {
            return name;
        }
    }
}
