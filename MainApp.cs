using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using LiveSplit.JumpKing;
using System.Reflection.Emit;
using System.Windows.Forms;
using Screen = LiveSplit.JumpKing.Screen;
using LiveSplit.Memory;
using System.IO;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;

namespace JumpKingRPC
{
    public partial class MainApp : System.Windows.Forms.Form
    {
        //inizializing stuff
        private SplitterMemory memory = new SplitterMemory();
        private float playerX;
        private float playerY;
        private Screen playerScreen = new Screen();
        DateTime date;
        TimeSpan gameTime;
        TimeSpan totalGameTime = new TimeSpan(TimeSpan.TicksPerDay);
        private Thread processThread;
        public DiscordRpcClient client;
        bool discStatus = false;
        bool gameStatus = false;
        bool giantBoots = false;
        bool snakeRing = false;
        int preset = 0;
        string off = "OFFLINE";
        string on = "OK!";
        string details;
        string level;
        string location;
        string state;
        string image;
        string simage;
        string stext;

        //form1_load is useless so far since app can count as MainApp
        private void Form1_Load(object sender, EventArgs e)
        {
            // stuff will go here eventually ¯\_(ツ)_/¯
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Environment.CurrentDirectory+"\\Images\\ttf_entercommand_bold.ttf");
            DescTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            CtrlTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
            StatsTitle.Font = new Font(pfc.Families[0], 16, FontStyle.Bold);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Deinitialize();
            memory.Dispose();
        }

        private void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void toolStripQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/");
        }

        private void toolStripShow_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        public MainApp()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            Text = "Jump King RPC v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            toolStripInfo.Text = Text;

            // JK and Discord process check thread
            client = new DiscordRpcClient("726077029195448430");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            processThread = new Thread(mainProcess);
            processThread.IsBackground = true;
            processThread.Start();
        }

        //this checks the status for the process
        public void mainProcess(object value)
        {
            while (true)
            {
                try
                {
                    //JK
                    if (!memory.HookProcess())
                    {
                        this.process.Invoke((MethodInvoker)delegate
                        {
                            this.process.Text = off;
                            this.process.ForeColor = System.Drawing.Color.Red;
                            this.toolTip.SetToolTip(this.process, "Process not found.");
                        });
                        discStatus = false;
                    }
                    else
                    {
                        this.process.Invoke((MethodInvoker)delegate
                        {
                            this.process.Text = on;
                            this.process.ForeColor = System.Drawing.Color.Green;
                            this.toolTip.SetToolTip(this.process, "JumpKing.exe has been found");
                        });
                        discStatus = true;

                        //check level
                        playerX = memory.PlayerX();
                        playerY = memory.PlayerY();
                        playerScreen = memory.PlayerScreen();
                        gameTime = TimeSpan.FromSeconds((int)Math.Round(memory.GameTime()));
                        totalGameTime = TimeSpan.FromSeconds((int)Math.Round(memory.TotalGameTime()));
                        Section(playerScreen, playerX, playerY);
                        this.panelStats.Invoke((MethodInvoker)delegate
                        {
                            this.liveSession.Text = "Session n." + memory.Sessions();
                            this.liveLevel.Text = "Level playing: " + level;
                            this.liveZone.Text = "Currently in: " + location;
                            if (!(playerX == 0) && !(playerY == 0))
                                this.toolTip.SetToolTip(this.liveZone, playerScreen.ToString());
                            this.liveJumpsFalls.Text = "Jumps: " + memory.LiveJumps() + "  —  Falls: " + memory.LiveFalls();
                            this.liveTimestamp.Text = "Time elapsed: " + (int)gameTime.TotalHours + gameTime.ToString("\\:mm\\:ss");
                            this.totalAttempts.Text = "Attempts count: " + memory.Attempts();
                            this.totalJumps.Text = "Total jumps: " + memory.Jumps();
                            this.totalFalls.Text = "Total falls: " + memory.Falls();
                            this.totalTimestamp.Text = "Time elapsed: " + (int)totalGameTime.TotalHours + totalGameTime.ToString("\\:mm\\:ss");
                        });
                    }
                    SmallImage(giantBoots, snakeRing);
                    Thread.Sleep(250);

                    //Discord
                    if (discStatus && gameStatus == false)
                    {
                        client.Initialize();
                        if (client.IsInitialized)
                            gameStatus = true;
                        date = DateTime.UtcNow;
                    }
                    else if (discStatus && gameStatus)
                    {

                        if (playerX == 0 && playerY == 0 && playerScreen == Screen.RedcrownWoods1)
                        {
                            client.SetPresence(new RichPresence()
                            {
                                Details = "Main Menu",
                                State = "",
                                Timestamps = new Timestamps()
                                {
                                    Start = date
                                },
                                Assets = new Assets()
                                {
                                    LargeImageKey = "jklogo",
                                    LargeImageText = details
                                }
                            });
                        }
                        else
                        {
                            UpdateRPC();
                        }

                        this.discordStatus.Invoke((MethodInvoker)delegate
                        {
                            this.discordStatus.Text = on;
                            this.discordStatus.ForeColor = System.Drawing.Color.Green;
                        });
                    }
                    else if (discStatus == false && gameStatus == true)
                    {
                        client.ClearPresence();
                        client.Deinitialize();
                        this.discordStatus.Invoke((MethodInvoker)delegate
                        {
                            this.discordStatus.Text = off;
                            this.discordStatus.ForeColor = System.Drawing.Color.Red;
                            this.toolTip.SetToolTip(this.discordStatus, "This can sometimes break.\r\nConsider reopening the application if it does not show up correctly.");
                        });
                        gameStatus = false;
                    }

                }
                catch (NotImplementedException notImp)
                {
                    Console.WriteLine("errorlol: " +notImp.Message);
                }
            }
        }

        //deinitialize Discord
        public void Deinitialize()
        {
            client.Dispose();
        }

        //method for shoes and ring
        public void SmallImage(bool boots, bool ring)
        {
            if (boots && ring) {
                simage = "shoes_and_ring";
                stext = "Using Giant Boots and Snake Ring";
            } else if (boots && ring == false) {
                simage = "shoes_iron";
                stext = "Using Giant Boots";
            } else if (boots == false && ring) {
                simage = "ring";
                stext = "Using Snake Ring";
            } else {
                simage = "";
                stext = "";
            }
        }

        //find location and description (nb,nbp,gotb)
        public void Section(Screen screen, float pX, float pY)
        {
            var enumType = typeof(Sections);
            var memberInfos = enumType.GetMember(Sections.RedcrownWoods.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var img = "";

            if (playerX == 0 && playerY == 0 && playerScreen == Screen.RedcrownWoods1)
            {
                details = "Main Menu";
                state = "";
                image = "jklogo";
            }
            else
            {
                switch (screen)
                {
                    //main babe ---------------------------------------------------------------------------
                    case Screen.RedcrownWoods1:
                    case Screen.RedcrownWoods2:
                    case Screen.RedcrownWoods3:
                    case Screen.RedcrownWoods4:
                    case Screen.RedcrownWoods5:
                        memberInfos = enumType.GetMember(Sections.RedcrownWoods.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.RedcrownWoods.GetDisplayName();
                        img = "redcrown_woods"; break;

                    case Screen.ColossalDrain1:
                    case Screen.ColossalDrain2:
                    case Screen.ColossalDrain3:
                    case Screen.ColossalDrain4:
                    case Screen.ColossalDrain5:
                        memberInfos = enumType.GetMember(Sections.ColossalDrain.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.ColossalDrain.GetDisplayName();
                        img = "colossal_drain"; break;

                    case Screen.FalseKingsKeep1:
                    case Screen.FalseKingsKeep2:
                    case Screen.FalseKingsKeep3:
                    case Screen.FalseKingsKeep4:
                        memberInfos = enumType.GetMember(Sections.FalseKingsKeep.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.FalseKingsKeep.GetDisplayName();
                        img = "falsekeep"; break;

                    case Screen.Bargainburg1:
                    case Screen.Bargainburg2:
                    case Screen.Bargainburg3:
                    case Screen.Bargainburg4:
                    case Screen.Bargainburg5:
                        memberInfos = enumType.GetMember(Sections.Bargainburg.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Bargainburg.GetDisplayName();
                        img = "bargainburg"; break;

                    case Screen.GreatFrontier1:
                    case Screen.GreatFrontier2:
                    case Screen.GreatFrontier3:
                    case Screen.GreatFrontier4:
                    case Screen.GreatFrontier5:
                    case Screen.GreatFrontier6:
                        memberInfos = enumType.GetMember(Sections.GreatFrontier.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.GreatFrontier.GetDisplayName();
                        img = "new_frontier"; break;

                    case Screen.WindsweptBluff1:
                        memberInfos = enumType.GetMember(Sections.WindsweptBluff.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.WindsweptBluff.GetDisplayName();
                        img = "windswept_bluff"; break;

                    case Screen.StormwallPass1:
                    case Screen.StormwallPass2:
                    case Screen.StormwallPass3:
                    case Screen.StormwallPass4:
                    case Screen.StormwallPass5:
                    case Screen.StormwallPass6:
                        memberInfos = enumType.GetMember(Sections.StormwallPass.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.StormwallPass.GetDisplayName();
                        img = "stormwall_pass"; break;

                    case Screen.ChapelPerilous1:
                    case Screen.ChapelPerilous2:
                    case Screen.ChapelPerilous3:
                    case Screen.ChapelPerilous4:
                        memberInfos = enumType.GetMember(Sections.ChapelPerilous.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.ChapelPerilous.GetDisplayName();
                        img = "chapel"; break;

                    case Screen.BlueRuin1:
                    case Screen.BlueRuin2:
                    case Screen.BlueRuin3:
                        memberInfos = enumType.GetMember(Sections.BlueRuin.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.BlueRuin.GetDisplayName();
                        img = "blue_ruin"; break;

                    case Screen.TheTower1:
                    case Screen.TheTower2:
                    case Screen.TheTower3:
                        memberInfos = enumType.GetMember(Sections.TheTower.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.TheTower.GetDisplayName();
                        img = "maintower"; break;

                    //babes ---------------------------------------------------------------------------

                    case Screen.MainBabe:
                    case Screen.Unknown1:
                        memberInfos = enumType.GetMember(Sections.MainBabe.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.MainBabe.GetDisplayName();
                        img = "mainbabe"; break;

                    case Screen.NewBabe:
                    case Screen.Unknown2:
                        memberInfos = enumType.GetMember(Sections.NewBabe.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.NewBabe.GetDisplayName();
                        img = "newbabe"; break;

                    case Screen.GhostBabe:
                    case Screen.Unknown3:
                        memberInfos = enumType.GetMember(Sections.GhostBabe.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.GhostBabe.GetDisplayName();
                        img = "ghostbabe"; break;

                    //new babe+ ---------------------------------------------------------------------------
                    case Screen.Bargainburg6:
                    case Screen.Bargainburg7:
                        memberInfos = enumType.GetMember(Sections.Bargainburg2.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Bargainburg2.GetDisplayName();
                        img = "improom"; break;

                    case Screen.BrightcrownWoods1:
                    case Screen.BrightcrownWoods2:
                    case Screen.BrightcrownWoods3:
                    case Screen.BrightcrownWoods4:
                    case Screen.BrightcrownWoods5:
                    case Screen.BrightcrownWoods6:
                        memberInfos = enumType.GetMember(Sections.BrightcrownWoods.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.BrightcrownWoods.GetDisplayName();
                        img = "brightcrown"; break;

                    case Screen.ColossalDungeon1:
                    case Screen.ColossalDungeon2:
                    case Screen.ColossalDungeon3:
                    case Screen.ColossalDungeon4:
                    case Screen.ColossalDungeon5:
                    case Screen.ColossalDungeon6:
                        memberInfos = enumType.GetMember(Sections.ColossalDungeon.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.ColossalDungeon.GetDisplayName();
                        img = "colossal_dungeon"; break;

                    case Screen.FalseKingsCastle1:
                    case Screen.FalseKingsCastle2:
                    case Screen.FalseKingsCastle3:
                    case Screen.FalseKingsCastle4:
                        memberInfos = enumType.GetMember(Sections.FalseKingsCastle.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.FalseKingsCastle.GetDisplayName();
                        img = "falsecastle"; break;

                    case Screen.Underburg1:
                    case Screen.Underburg2:
                    case Screen.Underburg3:
                    case Screen.Underburg4:
                    case Screen.Underburg5:
                    case Screen.Underburg6:
                    case Screen.Underburg7:
                        memberInfos = enumType.GetMember(Sections.Underburg.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Underburg.GetDisplayName();
                        img = "underburg"; break;

                    case Screen.LostFrontier1:
                    case Screen.LostFrontier2:
                    case Screen.LostFrontier3:
                    case Screen.LostFrontier4:
                    case Screen.LostFrontier5:
                    case Screen.LostFrontier6:
                    case Screen.LostFrontier7:
                        memberInfos = enumType.GetMember(Sections.LostFrontier.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.LostFrontier.GetDisplayName();
                        img = "lost_frontier"; break;

                    case Screen.HiddenKingdom1:
                    case Screen.HiddenKingdom2:
                    case Screen.HiddenKingdom3:
                    case Screen.HiddenKingdom4:
                    case Screen.HiddenKingdom5:
                    case Screen.HiddenKingdom6:
                        memberInfos = enumType.GetMember(Sections.HiddenKingdom.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.HiddenKingdom.GetDisplayName();
                        img = "hiddenkingdom"; break;

                    case Screen.BlackSanctum1:
                    case Screen.BlackSanctum2:
                    case Screen.BlackSanctum3:
                    case Screen.BlackSanctum4:
                    case Screen.BlackSanctum5:
                    case Screen.BlackSanctum6:
                        memberInfos = enumType.GetMember(Sections.BlackSanctum.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.BlackSanctum.GetDisplayName();
                        img = "black_sanctum"; break;

                    case Screen.DeepRuin1:
                    case Screen.DeepRuin2:
                    case Screen.DeepRuin3:
                    case Screen.DeepRuin4:
                    case Screen.DeepRuin5:
                        memberInfos = enumType.GetMember(Sections.DeepRuin.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.DeepRuin.GetDisplayName();
                        img = "deep_ruin"; break;

                    case Screen.TheDarkTower1:
                    case Screen.TheDarkTower2:
                    case Screen.TheDarkTower3:
                    case Screen.TheDarkTower4:
                    case Screen.TheDarkTower5:
                        memberInfos = enumType.GetMember(Sections.TheDarkTower.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.TheDarkTower.GetDisplayName();
                        img = "dark_tower"; break;

                    //new babe+ ---------------------------------------------------------------------------
                    case Screen.Bog1:
                    case Screen.Bog2:
                    case Screen.Bog3:
                    case Screen.Bog4:
                    case Screen.Bog5:
                    case Screen.Bog6:
                    case Screen.Bog7:
                        memberInfos = enumType.GetMember(Sections.Bog.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Bog.GetDisplayName();
                        img = "bog"; break;

                    case Screen.MouldingManor1:
                    case Screen.MouldingManor2:
                    case Screen.MouldingManor3:
                    case Screen.MouldingManor4:
                    case Screen.MouldingManor5:
                    case Screen.MouldingManor6:
                    case Screen.MouldingManor7:
                    case Screen.MouldingManor8:
                        memberInfos = enumType.GetMember(Sections.MouldingManor.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.MouldingManor.GetDisplayName();
                        img = "manor"; break;

                    case Screen.Bugstalk1:
                    case Screen.Bugstalk2:
                    case Screen.Bugstalk3:
                    case Screen.Bugstalk4:
                    case Screen.Bugstalk5:
                    case Screen.Bugstalk6:
                    case Screen.Bugstalk7:
                        memberInfos = enumType.GetMember(Sections.Bugstalk.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Bugstalk.GetDisplayName();
                        img = "bugstalk"; break;

                    case Screen.HouseOfNineLives1:
                    case Screen.HouseOfNineLives2:
                    case Screen.HouseOfNineLives3:
                    case Screen.HouseOfNineLives4:
                    case Screen.HouseOfNineLives5:
                    case Screen.HouseOfNineLives6:
                    case Screen.HouseOfNineLives7:
                        memberInfos = enumType.GetMember(Sections.HouseOfNineLives.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.HouseOfNineLives.GetDisplayName();
                        img = "tower_of_nine_lives"; break;

                    case Screen.PhantomTower1:
                    case Screen.PhantomTower2:
                    case Screen.PhantomTower3:
                    case Screen.PhantomTower4:
                    case Screen.PhantomTower5:
                    case Screen.PhantomTower6:
                    case Screen.PhantomTower7:
                    case Screen.PhantomTower8:
                    case Screen.PhantomTower9:
                        memberInfos = enumType.GetMember(Sections.PhantomTower.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.PhantomTower.GetDisplayName();
                        img = "phantom_tower"; break;

                    case Screen.HaltedRuin1:
                    case Screen.HaltedRuin2:
                    case Screen.HaltedRuin3:
                    case Screen.HaltedRuin4:
                    case Screen.HaltedRuin5:
                    case Screen.HaltedRuin6:
                    case Screen.HaltedRuin7:
                    case Screen.HaltedRuin8:
                        memberInfos = enumType.GetMember(Sections.HaltedRuin.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.HaltedRuin.GetDisplayName();
                        img = "halted_ruin"; break;

                    case Screen.TowerOfAntumbra1:
                    case Screen.TowerOfAntumbra2:
                    case Screen.TowerOfAntumbra3:
                    case Screen.TowerOfAntumbra4:
                    case Screen.TowerOfAntumbra5:
                    case Screen.TowerOfAntumbra6:
                        memberInfos = enumType.GetMember(Sections.TowerOfAntumbra.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.TowerOfAntumbra.GetDisplayName();
                        img = "antumbra"; break;

                    case Screen.PhilosophersForest1:
                    case Screen.PhilosophersForest2:
                    case Screen.PhilosophersForest3:
                    case Screen.PhilosophersForest4:
                    case Screen.PhilosophersForest5:
                        memberInfos = enumType.GetMember(Sections.PhilosophersForest.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.PhilosophersForest.GetDisplayName();
                        img = "philosopher"; break;

                    case Screen.Hole1:
                    case Screen.Hole2:
                    case Screen.Hole3:
                    case Screen.Hole4:
                        memberInfos = enumType.GetMember(Sections.Hole.ToString());
                        enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                        valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        level = ((DescriptionAttribute)valueAttributes[0]).Description;
                        location = Sections.Hole.GetDisplayName();
                        img = "philosopher"; break;
                }
                image = img;
                switch (preset)
                {
                    default:
                        details = level;
                        state = location;
                        break;
                    case 1:
                        details = location;
                        if (memory.LiveFalls() == 1) {
                            state = memory.LiveFalls().ToString() + " fall";
                        } else {
                            state = memory.LiveFalls().ToString() + " falls";
                        }
                        break;
                    case 2:
                        details = "Session n. " + memory.Sessions().ToString();
                        if (memory.LiveFalls() == 1) {
                            state = memory.LiveFalls().ToString() + " fall";
                        } else {
                            state = memory.LiveFalls().ToString() + " falls";
                        }
                        break;
                }
            }
        }
        public void UpdateRPC()
        {
            client.Invoke();
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = new Timestamps()
                {
                    Start = DateTime.UtcNow - gameTime
                },
                Assets = new Assets()
                {
                    LargeImageKey = image,
                    LargeImageText = location,
                    SmallImageKey = simage,
                    SmallImageText = stext
                }
            });
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (preset != comboBox1.SelectedIndex)
            preset = comboBox1.SelectedIndex;
        }

        private void checkGiantBoots_CheckedChanged(object sender, EventArgs e)
        {
            if (giantBoots != checkGiantBoots.Checked)
            giantBoots = checkGiantBoots.Checked;
        }

        private void checkSnakeRing_CheckedChanged(object sender, EventArgs e)
        {
            if (snakeRing != checkSnakeRing.Checked)
            snakeRing = checkSnakeRing.Checked;
        }
    }
}