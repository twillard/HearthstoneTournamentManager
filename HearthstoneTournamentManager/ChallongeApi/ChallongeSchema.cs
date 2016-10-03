using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

// Challonge JSON schema
// Note: this is not an exhaustive representation of the schema; only the fields
// useful to this application are present
// Schema documentation available here:
// http://api.challonge.com/v1/
//
// To update a match:
// https://api.challonge.com/v1/tournaments/twillard_test_tourney/matches/71538888.json?match[scores_csv]="1-0"&match[winner_id]=45954055
namespace ChallongeSchema
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "tournament")]
        public TournamentInfo Tournament { get; set; }
    }

    [DataContract]
    public class TournamentInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        // state could be "pending" or "underway" or...
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "participants")]
        public ParticipantWrapper[] Participants { get; set; }
        [DataMember(Name = "matches")]
        public MatchWrapper[] Matches { get; set; }
    }

    [DataContract]
    public class ParticipantWrapper
    {
        [DataMember(Name = "participant")]
        public ParticipantInfo Participant { get; set; }
    }

    [DataContract]
    public class MatchWrapper
    {
        [DataMember(Name = "match")]
        public MatchInfo Match { get; set; }
    }

    [DataContract]
    public class ParticipantInfo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class MatchInfo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        // could be "open" or "pending" or...
        [DataMember(Name = "state")]
        public string State { get; set; }
        [DataMember(Name = "player1_id")]
        public string Player1Id { get; set; }
        [DataMember(Name = "player2_id")]
        public string Player2Id { get; set; }
        [DataMember(Name = "winner_id")]
        public string WinnerId { get; set; }
        [DataMember(Name = "loser_id")]
        public string LoserId { get; set; }
    }
}
