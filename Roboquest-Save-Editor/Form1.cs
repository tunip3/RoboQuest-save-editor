using System.Collections;
using UnrealEngine.Gvas;
using UnrealEngine.Gvas.FProperties;

namespace Roboquest_Save_Editor
{
    public partial class Form1 : Form
    {
        SaveGameFile saveData;
        FMapProperty MetaRewards;
        public Form1()
        {
            InitializeComponent();
            Wrenches.Enabled = false;
            save.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Roboquest Save File|*.sav";
            openFileDialog1.Title = "Select a Roboquest Save File";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ "RoboQuest\\Saved\\SaveGames";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                savelocation.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(savelocation.Text))
            {
                MessageBox.Show("Please select a valid profile.sav file.");
                return;
            }

            saveData = SaveGameFile.LoadFrom(savelocation.Text);
            FProperty tempvalue;
            if (saveData.Root.Fields.TryGetValue("WrenchAmount", out tempvalue))
            {
                Wrenches.Value = (int)tempvalue.AsPrimitive();
            }
            Wrenches.Enabled = true;
            FProperty mapProperty;
            if(saveData.Root.Fields.TryGetValue("MetaRewards", out mapProperty))
            {
                MetaRewards = mapProperty as FMapProperty;
                FProperty tempproperty;
                foreach (var i in MetaRewards.KeyValuePairs)
                {
                    if (i.Key is FNameProperty j)
                    {
                        if (i.Value is FStructProperty fStruct)
                        {
                            if (fStruct.Fields.GetValueOrDefault("EntryLevel") is FArrayProperty fArray)
                            {
                                try
                                {
                                    switch (j.Value)
                                    {
                                        case "Level1":

                                            starterpack.Value = (int)fArray.Elements[0].AsPrimitive();
                                            powercellbank.Value = (int)fArray.Elements[1].AsPrimitive();
                                            powercellbank.Value = (int)fArray.Elements[1].AsPrimitive();
                                            fArray.Elements[1].SetValue(1);
                                            gadgetbundle1.Value = (int)fArray.Elements[2].AsPrimitive();
                                            break;
                                        case "Level2":
                                            l20.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l21.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l22.Value = (int)fArray.Elements[2].AsPrimitive();
                                            l23.Value = (int)fArray.Elements[3].AsPrimitive();
                                            l24.Value = (int)fArray.Elements[4].AsPrimitive();
                                            break;
                                        case "Level3":
                                            l30.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l31.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l32.Value = (int)fArray.Elements[2].AsPrimitive();
                                            l33.Value = (int)fArray.Elements[3].AsPrimitive();
                                            l34.Value = (int)fArray.Elements[4].AsPrimitive();
                                            l35.Value = (int)fArray.Elements[5].AsPrimitive();
                                            break;
                                        case "Level4":
                                            l40.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l41.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l42.Value = (int)fArray.Elements[2].AsPrimitive();
                                            l43.Value = (int)fArray.Elements[3].AsPrimitive();
                                            l44.Value = (int)fArray.Elements[4].AsPrimitive();
                                            l45.Value = (int)fArray.Elements[5].AsPrimitive();
                                            break;
                                        case "Level5":
                                            l50.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l51.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l52.Value = (int)fArray.Elements[2].AsPrimitive();
                                            l53.Value = (int)fArray.Elements[3].AsPrimitive();
                                            l54.Value = (int)fArray.Elements[4].AsPrimitive();
                                            l55.Value = (int)fArray.Elements[5].AsPrimitive();
                                            break;
                                        case "Level6":
                                            l60.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l61.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l62.Value = (int)fArray.Elements[2].AsPrimitive();
                                            l63.Value = (int)fArray.Elements[3].AsPrimitive();
                                            l64.Value = (int)fArray.Elements[4].AsPrimitive();
                                            break;
                                        case "Level7":
                                            l70.Value = (int)fArray.Elements[0].AsPrimitive();
                                            l71.Value = (int)fArray.Elements[1].AsPrimitive();
                                            l72.Value = (int)fArray.Elements[2].AsPrimitive();
                                            break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            
        }


        private void save_Click(object sender, EventArgs e)
        {
            FProperty wrenches;
            if (saveData.Root.Fields.TryGetValue("WrenchAmount", out wrenches))
            {
                wrenches.SetValue((int)Wrenches.Value);
            }


            MetaRewards = SaveGameFile.LoadFrom("meta.cfg").Root.Fields.GetValueOrDefault("MetaRewards") as FMapProperty;
            foreach (var pair in MetaRewards.KeyValuePairs)
            {
                FStructProperty fStruct = pair.Value as FStructProperty;
                FArrayProperty farray = fStruct.Fields["EntryLevel"] as FArrayProperty;
                switch ((pair.Key as FNameProperty).Value)
                {
                    case ("Level1"):
                        farray.Elements[0].SetValue((int)starterpack.Value);
                        farray.Elements[1].SetValue((int)powercellbank.Value);
                        farray.Elements[2].SetValue((int)gadgetbundle1.Value);
                        break;
                    case ("Level2"):
                        farray.Elements[0].SetValue((int)l20.Value);
                        farray.Elements[1].SetValue((int)l21.Value);
                        farray.Elements[2].SetValue((int)l22.Value);
                        farray.Elements[3].SetValue((int)l23.Value);
                        farray.Elements[4].SetValue((int)l24.Value);
                        break;
                    case ("Level3"):
                        farray.Elements[0].SetValue((int)l30.Value);
                        farray.Elements[1].SetValue((int)l31.Value);
                        farray.Elements[2].SetValue((int)l32.Value);
                        farray.Elements[3].SetValue((int)l33.Value);
                        farray.Elements[4].SetValue((int)l34.Value);
                        farray.Elements[5].SetValue((int)l35.Value);
                        break;
                    case ("Level4"):
                        farray.Elements[0].SetValue((int)l40.Value);
                        farray.Elements[1].SetValue((int)l41.Value);
                        farray.Elements[2].SetValue((int)l42.Value);
                        farray.Elements[3].SetValue((int)l43.Value);
                        farray.Elements[4].SetValue((int)l44.Value);
                        farray.Elements[5].SetValue((int)l45.Value);
                        break;
                    case ("Level5"):
                        farray.Elements[0].SetValue((int)l50.Value);
                        farray.Elements[1].SetValue((int)l51.Value);
                        farray.Elements[2].SetValue((int)l52.Value);
                        farray.Elements[3].SetValue((int)l53.Value);
                        farray.Elements[4].SetValue((int)l54.Value);
                        farray.Elements[5].SetValue((int)l55.Value);
                        break;
                    case ("Level6"):
                        farray.Elements[0].SetValue((int)l60.Value);
                        farray.Elements[1].SetValue((int)l61.Value);
                        farray.Elements[2].SetValue((int)l62.Value);
                        farray.Elements[3].SetValue((int)l63.Value);
                        farray.Elements[4].SetValue((int)l64.Value);
                        break;
                    case ("Level7"):
                        farray.Elements[0].SetValue((int)l70.Value);
                        farray.Elements[1].SetValue((int)l71.Value);
                        farray.Elements[2].SetValue((int)l72.Value);
                        break;
                }
            }

            FProperty mapProperty;
            if (saveData.Root.Fields.TryGetValue("MetaRewards", out mapProperty))
            {
                (mapProperty as FMapProperty).Name = MetaRewards.Name;
                (mapProperty as FMapProperty).KeyType = MetaRewards.KeyType;
                (mapProperty as FMapProperty).KeyValuePairs = MetaRewards.KeyValuePairs;
            }
                saveData.Save(savelocation.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}