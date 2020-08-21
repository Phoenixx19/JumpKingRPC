using System;
using DiscordRPC;
using DiscordRPC.Logging;
using JumpKing.MiscSystems.Achievements;
using JumpKing.Player;
using Microsoft.Xna.Framework;
using JumpKing.Player;

namespace JumpKingRPC
{
    class BodyValues
    {
		private Vector2 position;
		public Vector2 Position { get { return position; } set { position = value; } }
        // Token: 0x04000007 RID: 7
        private int time = 0;
		public int Time { get { return time; } set { time = value; } }
		// Token: 0x04000008 RID: 8
		private int lastScreen = 0;
		public int LastScreen { get { return lastScreen; } set { lastScreen = value; } }
		// Token: 0x04000009 RID: 9
		private int timeStamp = 0;
		public int TimeStamp { get { return timeStamp; } set { timeStamp = value; } }
		// Token: 0x0400000A RID: 10
		private bool windEnabled = false;
		public bool WindEnabled { get { return windEnabled; } set { windEnabled = value; } }

		public BodyValues(PlayerEntity player)
        {
            this.SetValues(player);
        }

		// Token: 0x0600000D RID: 13
		public void SetValues(PlayerEntity player)
		{
			if (player != null)
			{
				BodyComp body = player.m_body;
				this.WindEnabled = body.m_wind_enabled;
				this.Position = body.position;
				this.LastScreen = body.m_last_screen;
				this.TimeStamp = player.m_time_stamp;
			}
			if (AchievementManager.instance != null)
			{
				this.Time = AchievementManager.instance.m_all_time_stats._ticks;
			}
		}

		// Token: 0x0600000E RID: 14
		public void UpdateBody(PlayerEntity player)
		{
			BodyComp body = player.m_body;
			body.m_wind_enabled = this.WindEnabled;
			body.position = this.Position;
			body.m_last_screen = this.LastScreen;
			player.m_time_stamp = this.TimeStamp;
			AchievementManager.instance.m_all_time_stats._ticks = this.Time;
		}
	}
}
