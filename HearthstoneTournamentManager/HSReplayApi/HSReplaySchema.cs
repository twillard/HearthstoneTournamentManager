using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HSReplaySchema
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "shortid")]
        public string ShortId { get; set; }
        [DataMember(Name = "user")]
        public UserDetails User { get; set; }
        [DataMember(Name = "global_game")]
        public Game GlobalGame { get; set; }
        [DataMember(Name = "spectator_mode")]
        public bool SpectatorMode { get; set; }
        [DataMember(Name = "friendly_player_id")]
        public int FriendlyPlayerId { get; set; }
        [DataMember(Name = "replay_xml")]
        public string ReplayXml { get; set; }
        [DataMember(Name = "build")]
        public string Build { get; set; }
        [DataMember(Name = "won")]
        public bool Won { get; set; }
        [DataMember(Name = "disconnected")]
        public bool Disconnected { get; set; }
        [DataMember(Name = "reconnecting")]
        public bool Reconnecting { get; set; }
        [DataMember(Name = "visibility")]
        public int Visibility { get; set; }
    }

    [DataContract]
    public class UserDetails
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }
    }

    [DataContract]
    public class Game
    {
        [DataMember(Name = "build")]
        public string Build { get; set; }
        [DataMember(Name = "match_start")]
        public string MatchStart { get; set; }
        [DataMember(Name = "match_end")]
        public string MatchEnd { get; set; }
        [DataMember(Name = "game_type")]
        public int GameType { get; set; }
        [DataMember(Name = "brawl_season")]
        public int BrawlSeason { get; set; }
        [DataMember(Name = "ladder_season")]
        public int LadderSeason { get; set; }
        [DataMember(Name = "scenario_id")]
        public int ScenarioId { get; set; }
        [DataMember(Name = "players")]
        public Player[] Players { get; set; }
        [DataMember(Name = "num_turns")]
        public int NumTurns { get; set; }
        [DataMember(Name = "format")]
        public int Format { get; set; }
    }

    [DataContract]
    public class Player
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "player_id")]
        public int PlayerId { get; set; }
        [DataMember(Name = "account_hi")]
        public long AccountHi { get; set; }
        [DataMember(Name = "account_lo")]
        public long AccountLo { get; set; }
        [DataMember(Name = "is_ai")]
        public bool IsAi { get; set; }
        [DataMember(Name = "is_first")]
        public bool IsFirst { get; set; }
        [DataMember(Name = "hero_id")]
        public string HeroId { get; set; }
        [DataMember(Name = "hero_premium")]
        public bool HeroPremium { get; set; }
        [DataMember(Name = "final_state")]
        public int FinalState { get; set; }
        [DataMember(Name = "wins")]
        public string Wins { get; set; }
        [DataMember(Name = "losses")]
        public string Losses { get; set; }
        [DataMember(Name = "rank")]
        public string Rank { get; set; }
        [DataMember(Name = "legend_rank")]
        public string LegendRank { get; set; }
    }
}
