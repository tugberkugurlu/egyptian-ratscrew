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

    // http://www.wikihow.com/Play-Egyptian-Rat-Screw

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
        private readonly IEnumerable<Card> _centralPile;

        public GameState(IEnumerable<Card> centralPile)
        {
            if (centralPile == null)
            {
                throw new ArgumentNullException("centralPile");
            }

            _centralPile = centralPile;
        }
    }

    public class Deck
    {
        public Deck()
        {
            // TODO: Build the deck here. Put cards in order.
        }

        public void Shuffle()
        {
        }

        public IDictionary<Player, IEnumerable<Card>> Distribute(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException("players");
            }

            // TODO: try to find the dealer inside the players. throw if there is no.
            // TODO: return cards for each player as a dicktionary.

            throw new NotImplementedException();
        }
    }

    public class GameMove
    {
    }

    public class PlayerState
    {
        private readonly IEnumerable<Card> _faceDownCards;
        private readonly bool _isDealer;

        public PlayerState(IEnumerable<Card> faceDownCards, bool isDealer)
        {
            if (faceDownCards == null)
            {
                throw new ArgumentNullException("faceDownCards");
            }

            _faceDownCards = faceDownCards;
            _isDealer = isDealer;
        }
    }

    public class Player
    {
        private readonly byte _order;
        private readonly PlayerState _state;

        public Player(byte order, PlayerState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            _order = order;
            _state = state;
        }
    }

    /// <summary>
    /// A card from the deck of 52 playing cards.
    /// </summary>
    /// <remarks>
    /// For more information and complete list with photos, refer to <seealso cref="http://en.wikipedia.org/wiki/Standard_52-card_deck" />.
    /// </remarks>
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
}