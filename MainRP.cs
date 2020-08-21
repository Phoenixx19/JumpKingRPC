using System;
using DiscordRPC;
using DiscordRPC.Logging;
using JumpKing.MiscSystems.Achievements;
using JumpKing.Player;
using Microsoft.Xna.Framework;
using JumpKing.GameManager;
using JumpKing.SaveThread.SaveComponents;
using JumpKing.SaveThread;
namespace JumpKingRPC
{
	// Token: 0x02000002 RID: 2
	public class MainRP
	{
		BodyValues bodyValues = new BodyValues(GameLoop.m_player);
		// Token: 0x0400000B RID: 11
		public DiscordRpcClient client;
		public bool process = true;
		public DateTime time1 = new DateTime();
		public DateTime time2 = new DateTime();
		public TimeSpan pause = new TimeSpan();
		public DateTime menuElapsed = new DateTime();
		public int preset;
		public string text;
		public string image;
		public string section;
		public string smallimage;
		public string smalltext;

		public MainRP(int _preset)
        {
			switch (_preset)
            {
				case 1:
				case 2:
				case 3:
					preset = _preset;
					break;

				default:
					preset = 1;
					break;
            }
        }

		public void Run()
        {
			if (process)
            {
				if (time1 == DateTime.MinValue)
				{
					time1 = DateTime.Now;
				}
				time2 = DateTime.Now;
				pause = time2.Subtract(time1);

				if (pause.TotalMilliseconds > 400)
				{
					time1 = DateTime.Now;
					BootsRing(FullRunSave.fullRunSave.wear_giant_boots, FullRunSave.fullRunSave.wear_snake_ring);
					Update();
				}
			}
		}

		public void Init()
        {
			client = new DiscordRpcClient("726077029195448430");
			this.client.Logger = new ConsoleLogger
			{
				Level = LogLevel.Warning
			};
			this.client.Initialize();
		}

		public void Update()
        {
			//if the player is in-game or in-menu
			if (AchievementManager.instance.m_in_game_loop)
            {
				//time in menu elapsed reset
				if (menuElapsed != DateTime.MinValue)
					menuElapsed = DateTime.MinValue;

				//getvalues
                bodyValues.SetValues(GameLoop.m_player);
				
				//define richpresence to use
                IngameRP(preset);
			}
			else {
				if (menuElapsed == DateTime.MinValue)
					menuElapsed = DateTime.UtcNow;
				this.client.SetPresence(new RichPresence
				{
					Details = "Main Menu",
					State = "",
					Timestamps = new Timestamps
					{
						Start = menuElapsed
					},
					Assets = new Assets
					{
						LargeImageKey = "jklogo",
						LargeImageText = ""
					}
				});
			}
		}
		
		public void GetLocation(int screen)
        {
			if (screen <= 43) { if (section != "Main Babe") section = "Main Babe"; }
			else if (screen >= 44 && screen <= 100) { if (section != "New Babe Plus") section = "New Babe Plus"; }
			else if (screen >= 101 && screen <= 163) { if (section != "Ghost of the Babe") section = "Ghost of the Babe"; }
			switch (screen)
            {
				// main babe

                case int n when (n >= 0 && n <= 4):
					text = "Redcrown Woods"; image = "redcrown_woods"; break;

				case int n when (n >= 5 && n <= 9):
					text = "Colossal Drain"; image = "colossal_drain"; break;

				case int n when (n >= 10 && n <= 13):
					text = "False Kings' Keep"; image = "falsekeep"; break;

				case int n when (n >= 14 && n <= 18):
					text = "Bargainburg"; image = "bargainburg"; break;

				case int n when (n >= 19 && n <= 24):
					text = "Great Frontier"; image = "new_frontier"; break;
				
				case 25:
					text = "Windswept Bluff"; image = "windswept_bluff"; break;
				
				case int n when (n >= 26 && n <= 31):
					text = "Stormwall Pass"; image = "stormwall_pass"; break;

				case int n when (n >= 32 && n <= 35):
					text = "Chapel Perilous"; image = "chapel"; break;

				case int n when (n >= 36 && n <= 38):
					text = "Blue Ruin"; image = "blue_ruin"; break;

				case int n when (n >= 39 && n <= 41):
					text = "The Tower"; image = "maintower"; break;

				case 42:
					text = "Main Babe Screen"; image = "mainbabe"; break;

				case 43:
					text = "Unknown"; image = "mainbabe"; break;

					// new babe+

				case int n when (n >= 44 && n <= 45):
					text = "Room of the Imp"; image = "improom"; break;

				case int n when (n >= 46 && n <= 51):
					text = "Brightcrown Woods"; image = "brightcrown"; break;

				case int n when (n >= 52 && n <= 58):
					text = "Colossal Dungeon"; image = "colossal_dungeon"; break;

				case int n when (n >= 59 && n <= 62):
					text = "False Kings' Castle"; image = "falsecastle"; break;

				case int n when (n >= 63 && n <= 69):
					text = "Underburg"; image = "underburg"; break;

				case int n when (n >= 70 && n <= 76):
					text = "Lost Frontier"; image = "lost_frontier"; break;

				case int n when (n >= 77 && n <= 82):
					text = "Hidden Kingdom"; image = "hiddenkingdom"; break;

				case int n when (n >= 83 && n <= 88):
					text = "Black Sanctum"; image = "black_sanctum"; break;

				case int n when (n >= 89 && n <= 93):
					text = "Deep Ruin"; image = "deep_ruin"; break;

				case int n when (n >= 94 && n <= 98):
					text = "The Dark Tower"; image = "dark_tower"; break;

				case 99:
					text = "New Babe+ Screen"; image = "newbabe"; break;

				case 100:
					text = "Unknown"; image = "newbabe"; break;

					// gotb

				case int n when (n >= 101 && n <= 107):
					text = "Bog"; image = "bog"; break;

				case int n when (n >= 108 && n <= 115):
					text = "Moulding Manor"; image = "manor"; break;

				case int n when (n >= 116 && n <= 122):
					text = "Bugstalk"; image = "bugstalk"; break;

				case int n when (n >= 123 && n <= 129):
					text = "House Of Nine Lives"; image = "tower_of_nine_lives"; break;

				case int n when (n >= 130 && n <= 138):
					text = "Phantom Tower"; image = "phantom_tower"; break;

				case int n when (n >= 139 && n <= 146):
					text = "Halted Ruin"; image = "halted_ruin"; break;

				case int n when (n >= 147 && n <= 152):
					text = "Tower Of Antumbra"; image = "antumbra"; break;

				case 153:
					text = "Ghost Babe Screen"; image = "ghostbabe"; break;

				case 154:
					text = "Unknown"; image = "ghostbabe"; break;

				case int n when (n >= 155 && n <= 159):
					text = "Philosopher's Forest"; image = "philosopher"; break;

				case int n when (n >= 160 && n <= 163):
					text = "Hole"; image = "hole"; break;

				// default

				default:
					text = "Unknown"; image = "jklogo"; break;
			}
        }

		public void BootsRing(bool _boots, bool _ring)
        {
			if (_boots == true && _ring == false)
			{
				smallimage = "shoes_iron";
				smalltext = "Using Giant Boots";
			}
			else if (_ring == true && _boots == false)
			{
				smallimage = "ring";
				smalltext = "Using Snake Ring";
			}
			else if (_boots == true && _ring == true)
			{
				smallimage = "shoes_and_ring";
				smalltext = "Using Giant Boots and Snake Ring";
			}
			else if (_boots == false && _ring == false)
            {
				smallimage = "";
				smalltext = "";
            }
		}

		public void IngameRP(int _preset)
        {
			var gameTime = TimeSpan.FromSeconds((int)Math.Round((AchievementManager.instance.m_all_time_stats._ticks - AchievementManager.instance.m_snapshot._ticks) * 0.017f));
			var sessions = (AchievementManager.instance.m_all_time_stats.session - AchievementManager.instance.m_snapshot.session) + 1;
			var falls = AchievementManager.instance.m_all_time_stats.falls - AchievementManager.instance.m_snapshot.falls;

			GetLocation(bodyValues.LastScreen);
			switch (_preset)
            {
				//preset 1
				case 1:
					this.client.SetPresence(new RichPresence
					{
						Details = section,
						State = text,
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;

				//preset 2
				case 2:
					this.client.SetPresence(new RichPresence
					{
						Details = text,
						State = falls + " falls",
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;

				//preset 3
				case 3:
					this.client.SetPresence(new RichPresence
					{
						Details = "Session n.°"+sessions,
						State = falls+" falls",
						Timestamps = new Timestamps
						{
							Start = DateTime.UtcNow - gameTime
						},
						Assets = new Assets
						{
							LargeImageKey = image,
							LargeImageText = text,
							SmallImageKey = smallimage,
							SmallImageText = smalltext
						}
					});
					break;
            }
		}

		public void Stop()
        {
			process = false;
			client.Dispose();
		}
	}
}
