using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// </summary>
    /// <remarks>
    /// For more information on the game and its rules, refer to <seealso cref="http://en.wikipedia.org/wiki/Egyptian_Ratscrew" />
    /// </remarks>
    public class Game
    {
        // - For a game to be played, we need 2 or more player.
        // - Game is played Clockwise or Counterclockwise.
        // - Game class will be responsable for validating a game move and mutating the game state 
        // - based on the game move if the game move is valid.
        // - Game class should look at all what it got on the first construction and be able to say "wooo, this is state is wrong dude!".

        private readonly IEnumerable<Player> _players;
        private readonly GameState _state;

        public Game(IEnumerable<Player> players, GameState state)
        {
            if (players == null)
            {
                throw new ArgumentNullException("players");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            _players = players;
            _state = state;
        }
    }

    public class GameState
    {
    }

    public class GameMove
    {
    }

    public class PlayerState
    {
    }

    public class Player
    {
        private readonly PlayerState _state;

        public Player(PlayerState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            _state = state;
        }
    }

    public class Card
    {
        private readonly Suit _suit;
        private readonly Rank _rank;

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public override string ToString()
        {
            return string.Format("Card {0} of {1}", _rank, _suit);
        }

        protected bool Equals(Card other)
        {
            return _suit == other._suit && _rank == other._rank;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)_suit * 397) ^ (int)_rank;
            }
        }
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    /// <summary>
    /// List of the deck of 52 playing cards.
    /// </summary>
    /// <remarks>
    /// For more information and complete list with photos, refer to <seealso cref="http://en.wikipedia.org/wiki/Standard_52-card_deck" />.
    /// </remarks>
    public enum Cards
    {
        ClubsAce = 101,
        ClubsTwo = 102,
        ClubsThree = 103,
        ClubsFour = 104,
        ClubsFive = 105,
        ClubsSix = 106,
        ClubsSeven = 107,
        ClubsEight = 108,
        ClubsNine = 109,
        ClubsTen = 110,
        ClubsJack = 111,
        ClubsQueen = 112,
        ClubsKing = 113,

        DiamondsAce = 201,
        DiamondsTwo = 202,
        DiamondsThree = 203,
        DiamondsFour = 204,
        DiamondsFive = 205,
        DiamondsSix = 206,
        DiamondsSeven = 207,
        DiamondsEight = 208,
        DiamondsNine = 209,
        DiamondsTen = 210,
        DiamondsJack = 211,
        DiamondsQueen = 212,
        DiamondsKing = 213,

        HeartsAce = 301,
        HeartsTwo = 302,
        HeartsThree = 303,
        HeartsFour = 304,
        HeartsFive = 305,
        HeartsSix = 306,
        HeartsSeven = 307,
        HeartsEight = 308,
        HeartsNine = 309,
        HeartsTen = 310,
        HeartsJack = 311,
        HeartsQueen = 312,
        HeartsKing = 313,

        SpadesAce = 301,
        SpadesTwo = 302,
        SpadesThree = 303,
        SpadesFour = 304,
        SpadesFive = 305,
        SpadesSix = 306,
        SpadesSeven = 307,
        SpadesEight = 308,
        SpadesNine = 309,
        SpadesTen = 310,
        SpadesJack = 311,
        SpadesQueen = 312,
        SpadesKing = 313
    }

    public class CardMappings
    {
        private static readonly IDictionary<Cards, string> CardMappingDictionary = new Dictionary<Cards, string>
        {
            { Cards.ClubsAce, "" },
            { Cards.ClubsTwo, "" },
            { Cards.ClubsThree, "" },
            { Cards.ClubsFour, "" },
            { Cards.ClubsFive, "" },
            { Cards.ClubsSix, "" },
            { Cards.ClubsSeven, "" },
            { Cards.ClubsNine, "" },
            { Cards.ClubsTen, "" },
            { Cards.ClubsJack, "" },
            { Cards.ClubsQueen, "" },
            { Cards.ClubsKing, "" },

            { Cards.DiamondsAce, "" },
            { Cards.DiamondsTwo, "" },
            { Cards.DiamondsThree, "" },
            { Cards.DiamondsFour, "" },
            { Cards.DiamondsFive, "" },
            { Cards.DiamondsSix, "" },
            { Cards.DiamondsSeven, "" },
            { Cards.DiamondsNine, "" },
            { Cards.DiamondsTen, "" },
            { Cards.DiamondsJack, "" },
            { Cards.DiamondsQueen, "" },
            { Cards.DiamondsKing, "" },

            { Cards.HeartsAce, "" },
            { Cards.HeartsTwo, "" },
            { Cards.HeartsThree, "" },
            { Cards.HeartsFour, "" },
            { Cards.HeartsFive, "" },
            { Cards.HeartsSix, "" },
            { Cards.HeartsSeven, "" },
            { Cards.HeartsNine, "" },
            { Cards.HeartsTen, "" },
            { Cards.HeartsJack, "" },
            { Cards.HeartsQueen, "" },
            { Cards.HeartsKing, "" },

            { Cards.SpadesAce, "" },
            { Cards.SpadesTwo, "" },
            { Cards.SpadesThree, "" },
            { Cards.SpadesFour, "" },
            { Cards.SpadesFive, "" },
            { Cards.SpadesSix, "" },
            { Cards.SpadesSeven, "" },
            { Cards.SpadesNine, "" },
            { Cards.SpadesTen, "" },
            { Cards.SpadesJack, "" },
            { Cards.SpadesQueen, "" },
            { Cards.SpadesKing, "" }
        };

        private CardMappings()
        {
        }

        public string this[Cards i]
        {
            get
            {
            }
        }
    }
}