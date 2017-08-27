using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monster_Maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        List<Action> temp_actions = new List<Action>();
        List<Reaction> temp_reactions = new List<Reaction>();
        List<SpecialAbility> temp_specialabilities = new List<SpecialAbility>();
        List<LegendaryAction> temp_legendaryactions = new List<LegendaryAction>();


        private List<Monster> monsterList;

        private List<Monster> MonsterList
        {
            get { return monsterList; }
            set {
                monsterList = value;
                // on changed
                if(monsterList != null && monsterList.Count <= 0)
                LbMonsterList.DataContext = monsterList;
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            monsterList = new List<Monster>();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9][0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        

        private void BtnSaving_Click(object sender, RoutedEventArgs e)
        {
            if (!TbSaving.Text.Equals(""))
            {
                //List<skillssave> tete = new List<skillssave>();
                skillssave temp = new skillssave(CbSaving.Text, Convert.ToInt32(TbSaving.Text));
                bool test = LbSaving.Items.Contains(temp);
                if (!LbSaving.Items.Contains(temp))
                {
                    LbSaving.Items.Add(temp);
                    //LbSaving.ItemsSource = tete;
                }
                SortList(LbSaving,true);
            }

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSkills_Click(object sender, RoutedEventArgs e)
        {
            if (!TbSkills.Text.Equals(""))
            {
                skillssave temp = new skillssave(CbSkills.Text, Convert.ToInt32(TbSkills.Text));
                bool test = LbSkills.Items.Contains(temp);
                if (!LbSkills.Items.Contains(temp))
                {
                    LbSkills.Items.Add(temp);
                }
                SortList(LbSkills, false);
            }
        }

        
        //insert from workset into monsterList
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            var newMonster = new Monster()
            {
                name = TbName.Text,
                size = TbSize.Text,
                type = TbType.Text,
                alignment = TbAlignment.Text,
                armor_class = Convert.ToInt32(TbAC.Text),
                hit_dice = TbHP.Text,
                hit_points = CalculateHP(TbHP.Text),
                speed = TbSpeed.Text,
                senses = TbSens.Text,
                challenge_rating = Convert.ToInt32(TbChall.Text),
                strength = Convert.ToInt32(TbSTR.Text),
                dexterity = Convert.ToInt32(TbDEX.Text),
                constitution = Convert.ToInt32(TbCON.Text),
                intelligence = Convert.ToInt32(TbINT.Text),
                wisdom = Convert.ToInt32(TbWIS.Text),
                charisma = Convert.ToInt32(TbCHA.Text),
                special_abilities = temp_specialabilities,
                actions = temp_actions,
                reactions = temp_reactions,
                legendary_actions = temp_legendaryactions,
                languages = TbLang.Text
            };
            newMonster.AddPassiveToSenses();
            newMonster.insert_AbilityBonus();

            if(!TbDamRes.Text.Equals(""))
                newMonster.damage_resistances = TbDamRes.Text;
            if (!TbDamImm.Text.Equals(""))
                newMonster.damage_immunities = TbDamImm.Text;
            if (!TbDamVul.Text.Equals(""))
                newMonster.damage_vulnerabilities = TbDamVul.Text;
            if (!TbConImm.Text.Equals(""))
                newMonster.condition_immunities = TbConImm.Text;
            if (!TbSubtype.Text.Equals(""))
                newMonster.subtype = TbSubtype.Text;
        

            foreach (skillssave item in LbSkills.Items)
            {
                if (item.name == "Acrobatics (Dex)")
                    newMonster.acrobatics = item.amount;
                if (item.name == "Animal Handling (Wis)")
                    newMonster.animalHandling = item.amount;
                if (item.name == "Arcana (Int)")
                    newMonster.arcana = item.amount;
                if (item.name == "Athletics (Str)")
                    newMonster.athletics = item.amount;
                if (item.name == "Deception (Cha)")
                    newMonster.deception = item.amount;
                if (item.name == "History (Int)")
                    newMonster.history = item.amount;
                if (item.name == "Insight (Wis)")
                    newMonster.insight = item.amount;
                if (item.name == "Intimidation (Cha)")
                    newMonster.intimidation = item.amount;
                if (item.name == "Investigation (Int)")
                    newMonster.investigation = item.amount;
                if (item.name == "Medicine (Wis)")
                    newMonster.medicine = item.amount;
                if (item.name == "Nature (Int)")
                    newMonster.nature = item.amount;
                if (item.name == "Perception (Wis)")
                    newMonster.perception = item.amount;
                if (item.name == "Performance (Cha)")
                    newMonster.performance = item.amount;
                if (item.name == "Persuasion (Cha)")
                    newMonster.persuasion = item.amount;
                if (item.name == "Religion (Int)")
                    newMonster.religion = item.amount;
                if (item.name == "Sleight of Hand (Dex)")
                    newMonster.sleightOfHand = item.amount;
                if (item.name == "Stealth (Dex)")
                    newMonster.stealth = item.amount;
                if (item.name == "Survival (Wis)")
                    newMonster.survival = item.amount;
            }
            foreach (skillssave item in LbSaving.Items)
            {
                if (item.order == 1)
                    newMonster.strength_save = item.amount;
                if (item.order == 2)
                    newMonster.dexterity_save = item.amount;
                if (item.order == 3)
                    newMonster.constitution_save = item.amount;
                if (item.order == 4)
                    newMonster.intelligence_save = item.amount;
                if (item.order == 5)
                    newMonster.wisdom_save = item.amount;
                if (item.order == 6)
                    newMonster.charisma_save = item.amount;
            }


            monsterList.Add(newMonster);
            LbMonsterList.ItemsSource = monsterList;
        }


        private int CalculateHP(string hit_dice)
        {
            double postPlus;
            string PrePlus;
            double preMult;
            double postMult;
            string[] temp;

            hit_dice = hit_dice.ToLower().Trim();

            if (hit_dice.Contains("+"))
            {
                temp = hit_dice.Split('+');
                postPlus = Convert.ToDouble(temp[1]);
                PrePlus = temp[0];

                temp = PrePlus.Split('d');

                preMult = Convert.ToDouble(temp[0]);
                postMult = Convert.ToDouble(temp[1]);

                return Convert.ToInt32(preMult * ((postMult/2)+1) + postPlus);

            }
            else
            {
                temp = hit_dice.Split('d');

                preMult = Convert.ToDouble(temp[0]);
                postMult = Convert.ToDouble(temp[1]);

                return Convert.ToInt32(preMult * ((postMult / 2) + 1));
            }
                
        }

        //extract from monsterList to workset
        private void BtnExtract_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("todo");
        }
        //delete from monsterList
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("todo");
        }
        //clear workset
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbName.Clear();
            TbSize.Clear();
            TbType.Clear();
            TbSubtype.Clear();
            TbAlignment.Clear();
            TbAC.Clear();
            TbHP.Clear();
            TbSpeed.Clear();

            TbSTR.Clear();
            TbDEX.Clear();
            TbCON.Clear();
            TbINT.Clear();
            TbWIS.Clear();
            TbCHA.Clear();

            TbSaving.Clear();
            TbSkills.Clear();
            temp_actions.Clear();
            temp_reactions.Clear();
            temp_specialabilities.Clear();
            temp_legendaryactions.Clear();
            LbSaving.Items.Clear();
            LbSkills.Items.Clear();
            CbSaving.SelectedIndex = 0;
            CbSkills.SelectedIndex = 0;
            TbDamImm.Clear();
            TbDamRes.Clear();
            TbDamVul.Clear();
            TbConImm.Clear();
            TbChall.Clear();

        }

        private void SortList(ListBox lstBox,bool save)
        {
            IEnumerable<skillssave> list = null;
            if (save)
            {
                list = lstBox.Items.Cast<skillssave>().OrderBy(item => item.order).ToList();
            }else
            {
                list = lstBox.Items.Cast<skillssave>().OrderBy(item => item.name).ToList();
            }
            
            lstBox.Items.Clear();
            foreach (skillssave listItem in list)
            {
                lstBox.Items.Add(listItem);
            }
        }


        #region GUI Buttons
        private void BtnSavingDel_Click(object sender, RoutedEventArgs e)
        {
            if (LbSaving.SelectedIndex>=0)
            {
                LbSaving.Items.RemoveAt(LbSaving.SelectedIndex);
            }
        }

        private void BtnSkillDel_Click(object sender, RoutedEventArgs e)
        {
            if (LbSkills.SelectedIndex >= 0)
            {
                LbSkills.Items.RemoveAt(LbSkills.SelectedIndex);
            }
        }

        private void BtnSALock_Click(object sender, RoutedEventArgs e)
        {
            if (!TbSAName.Text.Equals("") && !TbSAName.Text.Equals(""))
            {
                SpecialAbility temp = new SpecialAbility(TbSAName.Text, TbSADisc.Text);
                temp_specialabilities.Add(temp);
                if (!LbSA.Items.Contains(temp))
                {
                    LbSA.Items.Add(temp);
                }
            }
            TbSAName.Text = ""; TbSADisc.Text = "";
        }

        private void BtnSADel_Click(object sender, RoutedEventArgs e)
        {
            if (LbSA.SelectedIndex >= 0)
            {
                LbSA.Items.RemoveAt(LbSA.SelectedIndex);
            }
        }

        private void BtnAcLock_Click(object sender, RoutedEventArgs e)
        {
            if (!TbAcName.Text.Equals("") && !TbAcName.Text.Equals(""))
            {
                Action temp = new Action(TbAcName.Text, TbAcDisc.Text);
                temp_actions.Add(temp);
                if (!LbAc.Items.Contains(temp))
                {
                    LbAc.Items.Add(temp);
                }
            }
            TbAcName.Text = ""; TbAcDisc.Text = "";
        }

        private void BtnAcDel_Click(object sender, RoutedEventArgs e)
        {
            if (LbAc.SelectedIndex >= 0)
            {
                LbAc.Items.RemoveAt(LbAc.SelectedIndex);
            }
        }

        private void BtnReLock_Click(object sender, RoutedEventArgs e)
        {
            if (!TbReName.Text.Equals("") && !TbReName.Text.Equals(""))
            {
                Reaction temp = new Reaction(TbReName.Text, TbReDisc.Text);
                temp_reactions.Add(temp);
                if (!LbRe.Items.Contains(temp))
                {
                    LbRe.Items.Add(temp);
                }
            }
            TbReName.Text = ""; TbReDisc.Text = "";
        }

        private void BtnReDel_Click(object sender, RoutedEventArgs e)
        {
            if (LbRe.SelectedIndex >= 0)
            {
                LbRe.Items.RemoveAt(LbRe.SelectedIndex);
            }
        }

        private void BtnLALock_Click(object sender, RoutedEventArgs e)
        {
            if (!TbLAName.Text.Equals("") && !TbLAName.Text.Equals(""))
            {
                LegendaryAction temp = new LegendaryAction(TbLAName.Text, TbLADisc.Text);
                temp_legendaryactions.Add(temp);
                if (!LbLA.Items.Contains(temp))
                {
                    LbLA.Items.Add(temp);
                }
            }
            TbLAName.Text = ""; TbLADisc.Text = "";
        }

        private void BtnLADel_Click(object sender, RoutedEventArgs e)
        {
            if (LbLA.SelectedIndex >= 0)
            {
                LbLA.Items.RemoveAt(LbLA.SelectedIndex);
            }
        }
        #endregion

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(monsterList);

            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\test.json";
            System.IO.File.WriteAllText(path, json);
        }
    }
}

//remove '.' @ senses
//language fout
//saves hebben 0.0 ipv 0